<?php
if (isset($_POST['amount']) && isset($_POST['currency']) && isset($_POST['interest']) && isset($_POST['period'])) {
    $amount = htmlentities($_POST['amount']);
    $currency = htmlentities($_POST['currency']);
    $interest = htmlentities($_POST['interest']);
    $period = htmlentities($_POST['period']);
    if ($period == "6months") {
        $period = 6;
    } else if ($period == "1year") {
        $period = 12;
    } else if ($period == "2years") {
        $period = 24;
    } else {
        $period = 60;
    }
    $result = round($amount * pow(1 + (($interest / 100) / 12), $period / 12 * 12), 2);
    if ($currency == "USD") {
        $result = "$ " . $result;
    } else if ($currency == "EUR") {
        $result = "&#8364; " . $result;
    } else {
        $result .= "Lv.";
    }
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Calculate Interest</title>
    </head>
    <body>
        <form method="post" action="CalculateInterest.php">
            <label for="amount">Enter Amount</label>
            <input type="text" name="amount" id="amount"/><br/>
            <input type="radio" name="currency" value="USD" id="usd"/>
            <label for="usd">USD</label>
            <input type="radio" name="currency" value="EUR" id="eur"/>
            <label for="eur">EUR</label>
            <input type="radio" name="currency" value="BGN" id="bgn"/>
            <label for="bgn">BGN</label><br/>
            <label for="interest">Compound Interest Amount</label>
            <input type="text" name="interest" id="interest"/><br/>
            <select name="period">
                <option value="6months">6 Months</option>
                <option value="1year">1 Year</option>
                <option value="2years">2 Years</option>
                <option value="5years">5 Years</option>
            </select>
            <input type="submit" value="Calculate"/>
        </form>
        <?php
        if (isset($result)) {
            echo($result);
        }
        ?>
    </body>
</html>