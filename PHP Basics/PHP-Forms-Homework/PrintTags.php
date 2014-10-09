<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Print Tags</title>
    </head>
    <body>
        <form method="post" action="PrintTags.php">
            <label for="tags">Enter Tags:</label><br/>
            <input type="text" name="tags" id="tags" required="true"/>
            <input type="submit" value="submit" name="submit"/>
        </form>
        <?php
        if (isset($_POST['tags'])) {
            $text = htmlentities($_POST['tags']);
            $arr = explode(', ', $text);
            for ($i = 0; $i < count($arr); $i++) {
                echo $i . ':' . $arr[$i] . "<br/>";
            }
        }
        ?>
    </body>
</html>