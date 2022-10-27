<?php

include "functions.php";

$nr = $_POST['zinr'];
$typ = $_POST['zityp'];
$desc = $_POST['beschreibung'];

$sth = $dbh->prepare(
    "INSERT INTO zimmer
      (zinr, zityp, beschreibung)
        VALUES
      (?, ?, ?)");
  
  $sth->execute(
    array(
      $nr,
      $typ,
      $desc
    )
  ); 

  //$id = $dbh->lastInsertID();
  header("Location: konfiguration.php");
?>