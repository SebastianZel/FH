<?php

include "functions.php";

$id = $_POST['zinr'];

$sth = $dbh->prepare("DELETE FROM zimmer WHERE zinr =? ");

if( ! $id = filter_var( $_POST['zinr'], FILTER_VALIDATE_INT ) ) {
    echo("Hack detected: Police will arrive shortly.");
    echo("variable id is false!");
    exit;
}

$sth->execute(array($id));
header("Location: konfiguration.php");
?>