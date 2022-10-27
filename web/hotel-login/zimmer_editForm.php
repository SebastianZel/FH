<!DOCTYPE html>
<html lang="de">

<?php
include "functions.php";
$pagetitle = "Room Edit";

$id = $_POST['zinr'];

$sth = $dbh->prepare("SELECT * FROM zimmer WHERE zinr = ? ");
$sth->execute(array($id));
$zimmer =  $sth->fetch();
$typesQuery = $dbh->query("SELECT zityp FROM zimmer GROUP BY zityp");
$types = $typesQuery->fetchAll();

include "header.php";
?>

<style>
    form {
        display: inline;
    }
</style>

<div class="overlay">
    <p>Information von Zimmer <?php echo $id ?> verändern:</p>

    <form method="post" action="zimmer_edit.php">
        <input type="Text" name="zinr" value="<?php echo $zimmer->zinr ?>" />
        <select name="zityp" value="<?php echo "htmlspecialchars($zimmer->zityp)" ?>">
            <?php foreach ($types as $t) {
                if ($t->zityp = $zimmer->zityp) {
                    echo "<option value='$t->zityp' selected >$t->zityp</option>";
                } else {
                    echo "<option value='$t->zityp'>$t->zityp</option>";
                }
            }
            ?>
        </select>
        <br>
        <input type="hidden" value="<?php echo "$id" ?>" name="oldZinr" />

        <textarea name="beschreibung" value="<?php htmlspecialchars($zimmer->beschreibung) ?>">
    <?php echo "$zimmer->beschreibung" ?>
    </textarea>
        <br>

        <input type="submit" value="Ändern">
    </form>

</div>