<?php
class Quest {
    private $firstName;
    private $secondName;
    private $id;

    function __construct($firstName, $secondName, $id)
    {
        $this->firstName = $firstName;
        $this->secondName = $secondName;
        $this->id = $id;
    }

    public function setFirstName($firstName)
    {
        $this->firstName = $firstName;
    }

    public function getFirstName()
    {
        return $this->firstName;
    }

    public function setId($id)
    {
        $this->id = $id;
    }

    public function getId()
    {
        return $this->id;
    }

    public function setSecondName($secondName)
    {
        $this->secondName = $secondName;
    }

    public function getSecondName()
    {
        return $this->secondName;
    }

    public function getFullName()
    {
        return "$this->firstName $this->secondName";
    }

    function __toString()
    {
        return $this->getFullName() . " - EGN: " . $this->id;
    }
}