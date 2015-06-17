<?php
if (isset($_GET['name']) && isset($_GET['gender']) && isset($_GET['pin'])) {
    $isValid = true;

    $gender = $_GET['gender'];
    if ($gender == "male") {
        $genderValue = 0;
    } else {
        $genderValue = 1;
    }

    $nameStr = $_GET['name'];
    $namePattern = '/[A-Z][a-z]+\s[A-Z][a-z]+/';
    preg_match($namePattern, $nameStr, $name);

    $pinStr = $_GET['pin'];
    $pinPattern = '/[0-9]{10}/';
    preg_match($pinPattern, $pinStr, $pin);

    if (empty($name) || empty($pin)) {
        $isValid = false;
    } else {
        $name = $name[0];
        $pin = $pin[0];
        $isValid = validate($pin, $genderValue);
    }

    if ($isValid) {
        $output = [
            "name" => $name,
            "gender" => $gender,
            "pin" => $pin
        ];
        echo json_encode($output);
    } else {
        echo "<h2>Incorrect data</h2>";
    }
}

function validate($pin, $genderValue) {
    $year = substr($pin, 0, 2);
    $month = substr($pin, 2, 2);
    $day = substr($pin, 4, 2);

    if ($month > 40) {
        $year = "20" . $year;
        $month = $month - 40;
    } else if ($month > 20) {
        $year = "12" . $year;
        $month = $month - 20;
    } else {
        $year = "19" . $year;
    }

    $dateStr = $day . "-" . $month . "-" . $year;
    $date = date_create($dateStr, timezone_open("Europe/Sofia"));

    if (!$date) {
        return false;
    }

    $monthChk = date_format($date, "m");
    if ($monthChk != $month) {
        return false;
    }

    $genderChk = substr($pin, 8, 1);
    if ($genderChk % 2 != $genderValue) {
        return false;
    }

    $sumChk = substr($pin, 9, 1);
    $weights = [2,4,8,5,10,9,7,3,6];
    $sum = 0;
    for ($i = 0; $i < 9; $i++) {
        $sum += substr($pin,$i,1) * $weights[$i];
    }
    $sum = $sum % 11 % 10;
    if ($sum != $sumChk) {
        return false;
    }
    return true;
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>3. PIN Validation</title>
</head>
<body>
<form method="get">
    <label>
        Name:
        <input type="text" name="name" />
    </label>
    <br />
    <label>
        male:
        <input type="radio" name="gender" value="male" />
    </label>
    <label>
        female:
        <input type="radio" name="gender" value="female" />
    </label>
    <br />
    <label>
        PIN:
        <input type="text" name="pin" />
    </label>
    <br />
    <input type="submit" value="Submit"/>
</form>
</body>
</html>