<?php
  $to = "fhs47843@fh-salzburg.ac.at";
  $subject = "wup wup";
  $message = $_REQUEST["message"];
  $email = $_REQUEST['email'];
  $headers .= "Reply-To: $email";
mail($to, $subject, $message, $email);
echo("Mail verschickt");
?> 