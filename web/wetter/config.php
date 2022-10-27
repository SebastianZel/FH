<?php

if ($_SERVER['HTTP_HOST'] == 'users.multimediatechnology.at') {
    $DB_NAME = "db1";
    $DB_USER = "db1_reader";
    $DB_PASS = "geheim!";  // fill in password here!!
    $DSN     = "pgsql:dbname=$DB_NAME;host=localhost";
} else {
    $DB_NAME = "weather";
    $DB_USER = "postgres"; // fill in your local db-username here!!
    $DB_PASS = "Sz24102001"; // fill in password here!!
    $DSN     = "pgsql:dbname=$DB_NAME;host=localhost";
}

$api_key = '123';

?>
