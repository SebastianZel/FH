<?php
    if ($_SERVER['HTTP_HOST'] == 'users.multimediatechnology.at') {
        $DB_NAME = "hotel_db";
        $DB_USER = "db1_reader";
        $DB_PASS = "geheim!";  // fill in password here!!
        $DSN     = "pgsql:dbname=$DB_NAME;host=localhost";
    } else {
        $DB_NAME = "hotel_db";
        $DB_USER = "postgres"; // fill in your local db-username here!!
        $DB_PASS = "Sz24102001"; // fill in password here!!
        $DSN     = "pgsql:dbname=$DB_NAME;host=localhost";
    }
?>
