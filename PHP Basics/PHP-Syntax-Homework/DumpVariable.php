<?php
function DumpVariable($var){
    if (is_numeric($var)) {
        var_dump($var);
    } else {
        echo gettype($var), "\n";
    }
}
DumpVariable("hello");
DumpVariable(15);
DumpVariable(1.234);
DumpVariable(array(1,2,3));
DumpVariable((object)[2,34]);
?>
