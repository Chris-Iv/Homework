<?php

class SearchController extends BaseController {
    private $db;

    public function onInit() {
        $this->title = 'Search';
        $this->db = new SearchModel();
    }

    public function index() {
        $this->showResults = false;
        if ($this->isPost) {
            $searchString = $_POST['search'];
            if (strlen($searchString) < 1) {
                $this->addErrorMessage('Cannot search for empty');
                return $this->renderView();
            }

            $this->issues = $this->db->search($searchString);
            $this->showResults = true;
            $this->renderView();
        }

        $this->renderView();
    }
}