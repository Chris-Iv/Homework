<?php

class IssuesModel extends BaseModel {
    public function createIssue($title, $description, $state, $submit_date, $author) {
        if ($title == '') {
            return false;
        }

        $statement = self::$db->prepare("INSERT INTO issues VALUES (NULL, ?, ?, ?, ?, ?)");
        $statement->bind_param("ssssd", $title, $description, $author, $state, $submit_date);
        $statement->execute();
        return $statement->affected_rows > 0;
    }

    public function editIssue($id, $title, $description, $state) {
        if ($title == '') {
            return false;
        }

        $statement = self::$db->prepare("UPDATE issues SET title = ?, description = ?, state = ? WHERE id = ?");
        $statement->bind_param('sssi', $title, $description, $state, $id);
        $statement->execute();
        return $statement->affected_rows > 0;
    }

    public function deleteIssue($id) {
        $statement = self::$db->prepare("DELETE FROM issues WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        return $statement->affected_rows > 0;
    }

    public function addComment($author, $text, $issue_id) {
        $statement = self::$db->prepare("INSERT INTO comments VALUES (NULL, ?, ?, ?)");
        $statement->bind_param("ssi", $author, $text, $issue_id);
        $statement->execute();
        return $statement->affected_rows > 0;
    }

    public function editComment($id, $text) {
        $statement = self::$db->prepare("UPDATE comments SET text = ? WHERE id = ?");
        $statement->bind_param("si", $text, $issue_id);
        $statement->execute();
        return $statement->affected_rows > 0;
    }

    public function deleteComment($id) {
        $statement = self::$db->prepare("DELETE FROM comments WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        return $statement->affected_rows > 0;
    }
}