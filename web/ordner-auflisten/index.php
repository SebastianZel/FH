<!DOCTYPE html>
<html>
<?php

$path = glob(img/"*.jpg")

if(is_dir($path)){
    $files = scandir($path);
   
        foreach($path as $val)
        {
            
            echo "<img src=$dir_path$files style='width: 150px;height: 150px;'><br>";
        }

       
    }
}


$dir_path = glob("img/*.jpg");

if(is_dir($dir_path)){
    $files = scandir($dir_path);
    for($i = 0 $i < count($files); $i++){
        if($files[$i] !='.' && $files[$i] != '. .'){
           
           
            $file = pathinfo($files[$i]);
            
            echo "<img src=$dir_path$files style='width: 150px;height: 150px;'><br>";
        }
    }
}


?>
</html>

