<?php
if (isset ($_POST['years'])) {
    $n = $_POST['years'];
    $result = '<table border="1"><thead><tr><td>Year</td><td>January</td><td>February</td><td>March</td><td>April</td><td>May</td><td>June</td><td>July</td><td>August</td><td>September</td><td>October</td>
    <td>November</td><td>December</td><td>Total:</td></tr></thead><tbody>';
    $currYear = 2014;
    for ($i = 0; $i < $n; $i++) {
        $num1 = rand(0, 999);
        $num2 = rand(0, 999);
        $num3 = rand(0, 999);
        $num4 = rand(0, 999);
        $num5 = rand(0, 999);
        $num6 = rand(0, 999);
        $num7 = rand(0, 999);
        $num8 = rand(0, 999);
        $num9 = rand(0, 999);
        $num10 = rand(0, 999);
        $num11 = rand(0, 999);
        $num12 = rand(0, 999);
        $total = $num1 + $num2 + $num3 + $num4 + $num5 + $num6 + $num7 + $num8 + $num9 + $num10 + $num11 + $num12;
        $year = $currYear - $i;
        $result .= "<tr><td>$year</td><td>$num1</td><td>$num2</td><td>$num3</td><td>$num4</td><td>$num5</td><td>$num6</td><td>$num7</td><td>$num8</td><td>$num9</td>
        <td>$num10</td><td>$num11</td><td>$num12</td><td>$total</td></tr>";
    }
    $result .= "</tbody></table>";
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Annual Expenses</title>
    </head>
    <body>
        <form method="post">
            <label for="years">Enter number of years:</label>
            <input type="text" name="years" id="years"/>
            <input type="submit" value="Show costs"/>
        </form>
        <?php
        if (isset ($result)) {
            echo $result;
        }
        ?>
    </body>
</html>