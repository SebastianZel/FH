<!DOCTYPE html>
<html lang="de">

<?php
include "functions.php";
include "users.php";
$pagetitle = "Login";

include "header.php";

if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    $userIn = htmlspecialchars($_POST['username']);
    $passIn = htmlspecialchars($_POST['password']);

    if (strlen($userIn) > 0  and $userIn == $userMaster and $passIn == $passMaster ) {
        $_SESSION['USER'] = $userMaster;
        header("Location: index.php");
        exit;
    }
    if (strlen($userIn) > 0  and $userIn == $userRegular and $passIn == $passRegular ) {
        $_SESSION['USER'] = $userRegular;
        header("Location: index.php");
        exit;
    }
}


?>

<form method="post" action="login.php">
    <label>Nutzername:<input type="Text" name="username" value="" /></label>
    <br>
    <label>Passwort:<input type="Text" name="password" value="" /></label>
    <br>
    <input type="submit" value="Login">
</form>



<?php
include "footer.php";
?>