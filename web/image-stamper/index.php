<?php


// Alle Warnings und Errors anzeigen - macht man eigentlich in Production nicht mehr
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

require __DIR__ . '/vendor/autoload.php';
require 'functions.php';

if( ! isset($_GET["url"]) ) {
    require "index-template.php";
    exit;
}



$url = $_GET["url"];

$client = new GuzzleHttp\Client();
$response = $client->request('GET', $url, ['verify' => false]);


$code = $response->getStatusCode();

if ( $code != 200 ) {
    $error = "Error loading the url: Status Code $code";
    require "index-template.php";
    exit;
}

$type = $response->getHeaderLine('content-type');

if ( $type != 'image/jpeg' ) {
    $error = "This is not an image, it is $type";
    require "index-template.php";

    exit;
}

if ( !is_writable('images/') ) {
    $error = "directory images/ is not writable";
    require "index-template.php";
    exit;
}

$data = $response->getBody();
$file = tempnam ( 'images/', 'img_');

$ok = file_put_contents(  $file, $data );
if ( ! $ok ) {
    $error = "could not save image to $file";
    require "index-template.php";

    exit;
}


try {

    $imagine = new Imagine\Gd\Imagine();


    $image = $imagine->open($file);

    $watermark = $imagine->open('assets/images/stamp.png');
    $size      = $image->getSize();
    $wSize     = $watermark->getSize();

    $bottomRight = new Imagine\Image\Point(10, $size->getHeight() - $wSize->getHeight());
    $image->paste($watermark, $bottomRight);

    $position = new Imagine\Image\Point( 50,  $size->getHeight() - 70);
    write($imagine, $image, date("d.M.Y"), '#ff0000', 16, $position);


    $position = new Imagine\Image\Point( 190,  $size->getHeight() - 65);
    write($imagine, $image, $url, '#0000ff', 10, $position);

    $image->save($file . ".jpg");

    //$image->show($file . '.jpg');


} catch( \RuntimeException  $e ) {
    $error = $e->getMessage();
    require "index-template.php";
    exit;
}

header("Location: index.php");

