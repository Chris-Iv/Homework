<?php

class AccountModel extends BaseModel {
    public function register($username, $password) {
        $is_admin = 'false';
        $statement = self::$db->prepare("SELECT COUNT(Id) FROM users WHERE username = ?");
        $statement->bind_param("s", $username);
        $statement->execute();
        $result = $statement->get_result()->fetch_assoc();
        if ($result['COUNT(Id)']) {
            return false;
        }

        $pass_hash = password_hash($password, PASSWORD_BCRYPT);

        $registerStatement = self::$db->prepare("INSERT INTO users (username, pass_hash, is_admin) VALUES (?, ?, ?)");
        $registerStatement->bind_param("sss", $username, $pass_hash, $is_admin);
        $registerStatement->execute();

        return true;
    }

    public function login($username, $password) {
        $statement = self::$db->prepare("SELECT id, username, pass_hash FROM users WHERE username = ?");
        $statement->bind_param("s", $username);
        $statement->execute();
        $result = $statement->get_result()->fetch_assoc();

        if (password_verify($password, $result['pass_hash'])) {
            return true;
        }

        return false;
    }

    public function isAdmin($username) {
        $statement = self::$db->prepare("SELECT is_admin FROM users WHERE username = ?");
        $statement->bind_param("s", $username);
        $statement->execute();
        $result = $statement->get_result()->fetch_assoc();
        return $result['is_admin'];
    }
}