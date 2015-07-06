<?php

class AccountController extends BaseController {
    private $db;

    public function onInit() {
        $this->db = new AccountModel();
    }

    public function register() {
        $this->title = 'Register';
        if ($this->isPost) {
            $username = $_POST['username'];
            if ($username == null || strlen($username) < 3) {
                $this->addErrorMessage('Username is invalid');
                $this->redirect('account', 'register');
            }

            $password = $_POST['password'];
            $isRegistered = $this->db->register($username, $password);
            if ($isRegistered) {
                $_SESSION['username'] = $username;
                $this->addInfoMessage('Registration successful');
                $this->redirect('home');
            }

            $this->addErrorMessage('Registration failed');
        }

        $this->renderView(__FUNCTION__);
    }

    public function login() {
        $this->title = 'Login';
        if ($this->isPost) {
            $username = $_POST['username'];
            $password = $_POST['password'];
            $isLoggedIn = $this->db->login($username, $password);
            if ($isLoggedIn) {
                $_SESSION['username'] = $username;
                $this->addInfoMessage('Login successful');
                $this->redirect('home');
            } else {
                $this->addErrorMessage('Login failed');
            }
        }

        $this->renderView(__FUNCTION__);
    }

    public function logout() {
        $this->authorize();
        unset($_SESSION['username']);
        $this->addInfoMessage('Logout successful');
        $this->redirect('home');
    }
}