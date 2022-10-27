<?php

if( $_SESSION['USER'] != "rezeption"){
    header("Location: errormessage.php");
}
    include "functions.php";
    $pagetitle = "Rezeption";

    $von = new DateTime( '2019-03-16' );
    $bis = new DateTime( '2019-03-31' );
    $bis = $bis->modify( '+1 day' );

    include "header.php";
?>
    <p>Belegung von
    <?php echo $formatter->format($von); ?>
    bis
    <?php echo $formatter->format($bis) ?>
    </p>

    <?php
        $tag_interval = DateInterval::createFromDateString('1 day');
        $tage = new DatePeriod($von, $tag_interval, $bis);
        foreach ($tage as $datum) {
            echo $formatter->format($datum);
        }
    ?>

<?php
    include "footer.php";
?>
