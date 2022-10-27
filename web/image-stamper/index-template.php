<?php error_log("display index-template.phnp"); ?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Bilder Stempeln</title>
    <style>
        form {display:flex;}
        input[type=text] {flex:1;}
        .error {
            background-color: red;
            padding: 4px;
        }
    </style>
</head>
<body>

    <?php if (isset($error)): ?>
        <div class="error"><?= $error ?></div>
    <?php endif; ?>

    <h1>Bilder mit Zeitstempel</h1>

    <form>
    URL des Bildes: 
    <input type="text" name="url" 
    placeholder="https://www.fh-salzburg.ac.at/fileadmin/_processed_/d/f/csm_FH-Salzburg_Campus-Kuchl-Student_Bibliothek-Kuchl_Design_web_13ed3e8aef.jpg"
    value="https://www.fh-salzburg.ac.at/fileadmin/_processed_/d/f/csm_FH-Salzburg_Campus-Kuchl-Student_Bibliothek-Kuchl_Design_web_13ed3e8aef.jpg">
    <input type="submit">
    </form>

    <h2>Gesammelte Bilder mit Zeitstempel</h2>

    <?php

      foreach( glob("images/*.jpg") as $img ) {
         echo "<img src='$img'>";
      }
    ?>

</body>
</html>