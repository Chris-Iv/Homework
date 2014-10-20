<?php
$recipient = htmlspecialchars($_GET['recipient']);
$subject = htmlspecialchars($_GET['subject']);
$message = htmlspecialchars($_GET['body']);
$key = $_GET['key'];

$formatted = "<p class='recipient'>" . $recipient .
    "</p><p class='subject'>" . $subject .
    "</p><p class='message'>" . $message . "</p>";

$result = encrypt($key, $formatted);
echo $result;

function encrypt($key, $formatted) {
    $encrypted = "|";
    $messageLen = strlen($formatted);
    $keyLen = strlen($key);

    for ($i = 0; $i < $messageLen; $i++) {
        $encryptChar = ord($formatted[$i]) * ord($key[$i % $keyLen]);
        $encrypted .= dechex($encryptChar) . "|";
    }

    return $encrypted;
}
?>