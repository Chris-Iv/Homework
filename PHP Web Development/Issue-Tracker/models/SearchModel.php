<?php

class SearchModel extends BaseModel {
    public function search($searchString) {
        $statement = self::$db->prepare("SELECT id, title, state FROM issues");
        $statement->execute();
        $issues = $statement->get_result()->fetch_all();
        $result = [];
        foreach ($issues as $issue) {
            if (strpos(strtolower($issue[1]), strtolower($searchString)) !== false) {
                array_push($result, $issue);
            }
        }

        return $result;
    }
}