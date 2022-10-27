<?php
include "users.php";

$_SESSION = array();

if (isset($_COOKIE[session_name()])) {
  setcookie(
    session_name(),  // Cookie-Name war gleich Name der Session 
    '',             // Cookie-Daten. Achtung! Leerer String hier hilft nicht!
    time()-42000,  // Ablaufdatum in der Vergangenheit. Erst das löscht!
    '/'           // Wirkungsbereich des Cookies: der ganze Server
   );
}
session_destroy();

header("Location: index.php");
?>