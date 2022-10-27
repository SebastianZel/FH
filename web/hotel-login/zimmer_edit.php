<?php
include "functions.php";

$id = $_POST['oldZinr'];

$nr = $_POST['zinr'];
$typ = $_POST['zityp'];
$desc = $_POST['beschreibung'];

$sth = $dbh->prepare("SELECT * FROM zimmer WHERE zinr=?");
$sth->execute(array($id));
$zimmer = $sth->fetch();

$sth = $dbh->prepare(
  "UPDATE zimmer SET
      zinr=?,zityp=?,beschreibung=? 
     WHERE zinr=?"
);

$update_went_ok = $sth->execute(
  array(
    $nr,
    $typ,
    $desc,    
    $id
  )
);

header("Location: konfiguration.php");
exit;
