<?php
if (isset($_POST['start']) && isset($_POST['end'])){
    $start = $_POST['start'];
    $end = $_POST['end'];
    if (isPrime($start)) {
        $result = "<b>$start</b>";
    } else {
        $result = $start;
    }
    for ($i = $start+1; $i <= $end; $i++) {
        if (isPrime($i)) {
            $result .= ', ' . "<b>$i</b>";
        } else {
            $result .= ', ' . $i;
        }
    }
}
function isPrime($num) {
    if($num == 1)
        return false;
    if($num == 2)
        return true;
    if($num % 2 == 0) {
        return false;
    }
    for($i = 3; $i <= ceil(sqrt($num)); $i = $i + 2) {
        if($num % $i == 0)
            return false;
    }
    return true;
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Primes In Range</title>
    </head>
    <body>
        <form method="post">
            <label for="start">Starting Index:</label>
            <input type="text" name="start" id="start"/>
            <label for="start">End:</label>
            <input type="text" name="end" id="end"/>
            <input type="submit" value="Submit"/>
        </form>
        <?php
        if (isset($result)) {
            echo $result;
        }
        ?>
    </body>
</html>