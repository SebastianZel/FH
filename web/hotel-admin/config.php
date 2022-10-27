<?php
    if ($_SERVER['HTTP_HOST'] == 'users.multimediatechnology.at') {
        $DB_NAME = "fhs47843_wp";
        $DB_USER = "fhs47843";
        $DB_PASS = "xdyqWG92Rlbm";  // fill in password here!!
        $DSN     = "pgsql:dbname=$DB_NAME;host=localhost";
    } else {
        $DB_NAME = "hotel_db";
        $DB_USER = "postgres"; // fill in your local db-username here!!
        $DB_PASS = "Sz24102001"; // fill in password here!!
        $DSN     = "pgsql:dbname=$DB_NAME;host=localhost";
    }
?>
