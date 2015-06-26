<?php

class HomeController extends BaseController {
    private $db;

    public function onInit() {
        $this->title = 'Issue Tracker';
        $this->db = new HomeModel();
    }

    public function index($page = DEFAULT_PAGE, $pageSize = DEFAULT_PAGE_SIZE, $state = 'All') {
        $from = $page * $pageSize;
        $this->page = $page;
        $this->pageSize = $pageSize;
        $this->issues = $this->db->getFilteredIssues($from, $pageSize, $state);
        $this->renderView();
    }

    public function showDetails($id) {
        $this->details = $this->db->getIssue($id);
        $this->comments = $this->db->getComments($id);
        $_SESSION['issue_id'] = $id;
        $this->renderView(__FUNCTION__, false);
    }
}