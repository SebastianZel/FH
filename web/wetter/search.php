<?php
  include "config.php";

  if( ! $DB_NAME ) die('please create config.php, define $DB_NAME, $DSN, $DB_USER, $DB_PASS there');

  try {
    $dbh = new PDO($DSN, $DB_USER, $DB_PASS);
    $dbh->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $dbh->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);

    $sth = $dbh->prepare(
      "SELECT CONCAT(name, ' ', country) as label FROM city WHERE name ILIKE ? ORDER BY name LIMIT 5000"
    );

    // man sollte was mit $_GET['term'] machen...
    $search_term = $_GET['term'] . '%';

    $sth->execute(array($search_term));
    $cities = $sth->fetchAll(PDO::FETCH_COLUMN);

  } catch (Exception $e) {
    die("Problem connecting to database $DB_NAME as $DB_USER: " . $e->getMessage() );
  }

// Und natürlich muss man die JSON Response auch zurückgeben
header('Content-Type: application/json');
// $cities aus der Datenbank holen
echo json_encode($cities);
?>

