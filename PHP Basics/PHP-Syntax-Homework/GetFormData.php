<?php
$result = "";
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $name = $_POST['name'];
    $age = $_POST['age'];
    $gender = $_POST['gender'];
    $result = "My name is $name. I am $age years old. I am $gender.";
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Get Form Data</title>
        <style>
            input[type="text"], label {
                display: block;
            }
        </style>
    </head>
    <body>
        <form method="post">
            <input type="text" name="name" placeholder="Name..."/>
            <input type="text" name="age" placeholder="Age..."/>
            <label for="male">Male</label>
            <input type="radio" name="gender" id="male" value="male"/>
            <label for="female">Female</label>
            <input type="radio" name="gender" id="female" value="female"/>
            <input type="submit" value="Submit"/>
        </form>
    <?php echo($result); ?>
    </body>
</html>