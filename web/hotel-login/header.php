<!DOCTYPE html>
<html lang="de">
  <?php include "users.php"; ?>

<head>
  <meta charset="utf-8">
  <title>Hotel Oceanside - <?php echo $pagetitle ?></title>
  <link rel="stylesheet" href="style.css">
</head>
<body>
  <nav>
    <ul>
      <li><a href="index.php">Home</a></li>
      <?php 
      if ($_SESSION['USER'] == $userMaster) echo <<<EOL
      <li><a href="buchungen.php">Buchungen</a></li>
      <li><a href="plan.php">Plan</a></li>
      <li><a href="konfiguration.php">Konfiguration</a></li>
      <li><a href="logout.php">Logout</a></il>
      EOL;
      else if (($_SESSION['USER'] == $userRegular)){
        echo  '<li><a href="plan.php">Plan</a></li>';
        echo  '<li><a href="logout.php">Logout</a></il>';
     
      }
      else echo('<li><a href="login.php">Login</a></li>'); ?>
    </ul>
  </nav>
  <main>
    <h1>Hotel Oceanside <small><?php echo $pagetitle ?></small></h1>

