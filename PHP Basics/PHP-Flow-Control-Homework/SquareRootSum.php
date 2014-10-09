<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Square Root Sum</title>
    </head>
    <body>
        <table border="1">
            <thead>
                <tr>
                    <td>Number</td>
                    <td>Square</td>
                </tr>
            </thead>
            <tbody>
                <?php
                $sum = 0;
                for ($i = 0; $i <= 100; $i += 2) {
                    echo "<tr><td>$i</td><td>" . round(sqrt($i), 2) . "</td></tr>";
                    $sum += sqrt($i);
                }
                ?>
            </tbody>
            <tfoot>
                <tr>
                    <td>Total:</td>
                    <td><?= round($sum, 2) ?></td>
                </tr>
            </tfoot>
        </table>
    </body>
</html>