<?php
if (isset($_POST['cars'])) {
    $allCars = explode(', ', $_POST['cars']);
    $allColors = array('aqua', 'black', 'blue', 'fuchsia', 'gray', 'green', 'lime', 'maroon', 'navy',
        'olive', 'orange', 'purple', 'red', 'silver', 'teal', 'white', 'yellow');
    $result = '<table border="1"><thead><tr><td>Car</td><td>Color</td><td>Count</td></tr></thead><tbody>';
    for ($i = 0; $i < count($allCars); $i++) {
        $color = $allColors[rand(0, 16)];
        $count = rand(1, 5);
        $result .= "<tr><td>$allCars[$i]</td><td>$color</td><td>$count</td></tr>";
    }
    $result .= '</tbody></table>';
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Car Randomizer</title>
    </head>
    <body>
        <form method="post">
            <label for="cars">Enter cars</label>
            <input type="text" name="cars" id="cars"/>
            <input type="submit" value="Show result"/>
        </form>
        <?php
        if (isset ($result)) {
            echo $result;
        }
        ?>
    </body>
</html>