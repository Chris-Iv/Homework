<?php

class HomeModel extends BaseModel {
    public function getIssue($id) {
        $statement = self::$db->prepare("SELECT description, author, state, submit_date FROM issues WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        $result = $statement->get_result()->fetch_assoc();
        return $result;
    }

    public function getFilteredIssues($from, $size, $state) {
        if ($state == 'All') {
            $statement = self::$db->prepare("SELECT id, title, state FROM issues LIMIT ?, ?");
            $statement->bind_param("ii", $from, $size);
        } else {
            $statement = self::$db->prepare("SELECT id, title, state FROM issues WHERE state = ? LIMIT ?, ?");
            $statement->bind_param("sii", $state, $from, $size);
        }

        $statement->execute();
        $result = $statement->get_result()->fetch_all();
        return $result;
    }

    public function getComments($id) {
        $statement = self::$db->prepare("SELECT id, author, text, issue_id FROM comments WHERE issue_id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        $result = $statement->get_result()->fetch_all();

        return $result;
    }
}