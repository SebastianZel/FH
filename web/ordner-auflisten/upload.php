<?php
$uploaddir = dirname( $_SERVER["SCRIPT_FILENAME"] ) . "/img";

$filename = basename($_FILES['bild']['name']);
$ext = substr($filename, -4);

if( $ext != '.jpg' ) {
   die("ich darf nur jpg-Dateien hochladen, nicht " . $ext );
}

$uploadfile = $uploaddir . $filename;

if (move_uploaded_file($_FILES['bild']['tmp_name'], $uploadfile)) {
  echo "Datei erfolgreich hochgeladen.\n";
} else {
  echo "Problem beim Speichern der Datei.\n";
}

echo '<pre>debugging info:';
print_r($_FILES);
print '</pre>';
?>