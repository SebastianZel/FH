<!DOCTYPE html>
<html lang="de">

<style>
  form {
    display: inline;
  }
</style>

<?php
if( $_SESSION['USER'] != "rezeption"){
  header("Location: errormessage.php");
}
include "functions.php";
$pagetitle = "Hotel Konfiguration";

$sth = $dbh->query("SELECT * FROM zimmer");
$typesQuery = $dbh->query("SELECT zityp FROM zimmer GROUP BY zityp");
$types = $typesQuery->fetchAll();
$zimmer =  $sth->fetchall();

include "header.php";
?>

<div class="overlay">
  <p>Hier sind alle Zimmer des Hotels aufgelistet. Nach Umbauten kann
    man hier die Daten zu den Zimmern ändern, Zimmer hinzufügen und Löschen.</p>

  <?php
  foreach ($zimmer as $z) {
  ?>
    <form method="post" action="zimmer_delete.php">
      <p><b><?php echo $z->zinr ?></b> vom Typ <?php echo $z->zityp ?>
      <?php echo "[$z->beschreibung]"?>
      
        <input type="hidden" value="<?php echo $z->zinr ?>" name="zinr" />
        <input type="submit" value="löschen" />
        <input type="submit" value="editieren" formaction="zimmer_editForm.php" />
      </p>
    </form>

  <?php
  }
  ?>

  <form method="post" action="zimmer_new.php">
    <input type="Text" name="zinr" value="<?php htmlspecialchars($z->zinr) ?>" />
    <select name="zityp" value="<?php htmlspecialchars($z->zityp) ?>">
    <?php foreach ($types as $t)
    {
      echo "<option value='$t->zityp'>$t->zityp</option>";
    }
    ?>
    </select>
    <br>

    <textarea name="beschreibung" value="<?php htmlspecialchars($z->beschreibung) ?>"></textarea>
    <br>

    <input type="submit" value="new">
  </form>  

</div>




<?php
include "footer.php";
?>