
<?php

function write($imagine, $image, $text, $color, $size, $position) {
    $fontColor = $image->palette()->color($color); 
    $fontfilename = __DIR__ . '/assets/fonts/Roboto-Regular.ttf'; 
    $font = $imagine->font($fontfilename, $size, $fontColor);  
    error_log("write $text");
    $image->draw()->text($text, $font, $position); 
}
