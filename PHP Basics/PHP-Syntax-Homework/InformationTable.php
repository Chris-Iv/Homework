<?php
$name = "Gosho";
$phone = "0882-321-423";
$age = 24;
$address = "Hadji Dimitar";
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8"/>
        <title>Information Table</title>
        <style>
            table {
                text-indent: 5px;
                border-collapse: collapse;
            }
            table tr {
                border: 1px solid #000;
            }
            table th, table td {
                width: 120px;
                line-height: 25px;
            }
            table th {
                text-align: left;
                background: #FFA100;
                border-right: 1px solid #000;
            }
            table td {
                text-align: right;
                padding-right: 5px;
            }
        </style>
    </head>
    <body>
        <table>
            <tbody>
                <tr>
                    <th>Name</th>
                    <td><?php echo($name); ?></td>
                </tr>
                <tr>
                    <th>Phone Number</th>
                    <td><?php echo($phone); ?></td>
                </tr>
                <tr>
                    <th>Age</th>
                    <td><?php echo($age); ?></td>
                </tr>
                <tr>
                    <th>Address</th>
                    <td><?php echo($address); ?></td>
                </tr>
            </tbody>
        </table>
    </body>
</html>