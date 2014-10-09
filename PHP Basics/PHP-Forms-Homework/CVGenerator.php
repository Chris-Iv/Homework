<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>CV Generator</title>
    <style>
        section form fieldset {
            width: 550px;
        }
        section fieldset p {
            margin: 0px;
        }
        section form fieldset:nth-child(1) input{
            display: block
        }
        section form fieldset:nth-child(1) input[type='radio']{
            display: inline-block;
        }
        section form fieldset:nth-child(1) select{
            display: block
        }
        table{
            border: 1px solid black;
            margin-bottom: 20px;
        }
        body > section:nth-child(2) > table:nth-child(4) > tbody > tr > td:nth-child(2) > table,
        body > section:nth-child(2) > table:nth-child(5) > tbody > tr:nth-child(1) > td:nth-child(2) > table{
            margin:0px;
        }
        tr, td, thead, th {
            border: 1px solid black;
            padding: 5px;
        }
    </style>
    <script>
        var divProgId = 0;
        function addProgramLang(){
            var newProgDiv = document.createElement("div");
            newProgDiv.setAttribute("id", "progDiv" + divProgId);
            divProgId++;
            newProgDiv.innerHTML = '<input type="text" name="programmingLanguages[]"/>' +
                '<select name="level-prog-lang[]">' +
                '<option value="Beginner">Beginner</option>' +
                '<option value="Programmer">Programmer</option>' +
                '<option value="Ninja">Ninja</option>' +
                '</select>';
            document.getElementById("parentProgrammingLanguages").appendChild(newProgDiv);
        }
        function removeProgramLang(){
            var lastProgDiv = document.getElementById("parentProgrammingLanguages").lastChild;
            if(lastProgDiv.id != "progDiv0"){
                document.getElementById("parentProgrammingLanguages").lastChild.remove();
            }
        }
        var divLangId = 0;
        function addLang(){
            var newLangDiv = document.createElement("div");
            newLangDiv.setAttribute("id", "langDiv" + divLangId);
            divLangId++;
            newLangDiv.innerHTML = '<input type="text" name="languages[]">' +
                '<select name="comprehension[]">' +
                '<option disabled selected>-Comprehension-</option>' +
                '<option value="Beginner">Beginner</option>' +
                '<option value="Intermediate">Intermediate</option>' +
                '<option value="Advanced">Advanced</option>' +
                '</select>' +
                '<select name="reading[]">' +
                '<option disabled selected>-Reading-</option>' +
                '<option value="Beginner">Beginner</option>' +
                '<option value="Intermediate">Intermediate</option>' +
                '<option value="Advanced">Advanced</option>' +
                '</select>' +
                '<select name="writing[]">'+
                '<option disabled selected>-Writing-</option>'+
                '<option value="Beginner">Beginner</option>'+
                '<option value="Intermediate">Intermediate</option>'+
                '<option value="Advanced">Advanced</option>'+
                '</select>';
            document.getElementById("parentLanguages").appendChild(newLangDiv);
        }
        function removeLang(){
            var lastLangDiv = document.getElementById("parentLanguages").lastChild;
            if(lastLangDiv.id != "langDiv0"){
                document.getElementById("parentLanguages").lastChild.remove();
            }
        }
    </script>
</head>
<body>
<section>
    <form method="post">
        <fieldset>
            <legend>Personal Information</legend>
            <input type="text" name="fName" placeholder="First Name" >
            <input type="text" name="lName" placeholder="Last Name" >
            <input type="email" name="email" placeholder="Email" >
            <input type="text" name="phoneNum" placeholder="Phone Number" >
            <div>
                <label for="female">Female</label>
                <input type="radio" name="sex" id="female" value="female" >
                <label for="male">Male</label>
                <input type="radio" name="sex" id="male" value="female" >
            </div>
            <label for="bDate">Birth Date</label>
            <input type="date" name="bDate" id="bDate" >
            <label for="nationality">Nationality</label>
            <select name="nationality" id="nationality" >
                <option disabled selected>-Nationality-</option>
                <option value="Bulgarian">Bulgarian</option>
                <option value="Danish">Danish</option>
                <option value="German">German</option>
                <option value="British">British</option>
            </select>
        </fieldset>
        <fieldset>
            <legend>Last Work Position</legend>
            <div>
                <label for="companyName">Company Name</label>
                <input type="text" name="companyName" id="companyName">
            </div>
            <div>
                <label for="fromDate">From</label>
                <input type="date" name="fromDate" id="fromDate">
            </div>
            <div>
                <label for="toDate">To</label>
                <input type="date" name="toDate" id="toDate">
            </div>
        </fieldset>
        <fieldset>
            <legend>Computer Skills</legend>
            <p>Programming Languages</p>
            <div id="parentProgrammingLanguages">
            </div>
            <script>addProgramLang();</script>
            <input type="button" value="Remove Language" onclick="removeProgramLang()"/>
            <input type="button" value="Add Language" onclick="addProgramLang()"/>
        </fieldset>
        <fieldset>
            <legend>Other Skills</legend>
            <p>Languages</p>
            <div id="parentLanguages">
            </div>
            <script>addLang();</script>
            <input type="button" value="Remove Language" onclick="removeLang()"/>
            <input type="button" value="Add Language" onclick="addLang()"/>
            <p>Driver's License</p>
            <label for="b-cat">B</label>
            <input type="checkbox" name="bCategory" id="b-cat" value="B">
            <label for="a-cat">A</label>
            <input type="checkbox" name="aCategory" id="a-cat" value="A">
            <label for="c-cat">C</label>
            <input type="checkbox" name="cCategory" id="c-cat" value="C">
        </fieldset>
        <input type="submit" name="generateCV" value="Generate CV">
    </form>
</section>
<?php
if(isset($_POST['fName']) && isset($_POST['lName']) && isset($_POST['email']) && isset($_POST['phoneNum']) &&
    isset($_POST['sex']) && isset($_POST['bDate']) && isset($_POST['nationality']) && isset($_POST['companyName']) && isset($_POST['fromDate']) &&
    isset($_POST['toDate']) && isset($_POST['programmingLanguages']) && isset($_POST['languages']) && isset($_POST['comprehension']) && isset($_POST['reading']) &&
    isset($_POST['writing'])){
    $firstName = htmlentities($_POST['fName']);
    $lastName = htmlentities($_POST['lName']);
    $email = htmlentities($_POST['email']);
    $phoneNum = htmlentities($_POST['phoneNum']);
    $sex = $_POST['sex'];
    $birthDate = $_POST['bDate'];
    $nationality = $_POST['nationality'];
    $companyName = htmlentities($_POST['companyName']);
    $fromDate = $_POST['fromDate'];
    $toDate = $_POST['toDate'];
    $programmingLanguage = $_POST['programmingLanguages'];
    $levelProgLang = $_POST['level-prog-lang'];
    $language = $_POST['languages'];
    $langComprehension = $_POST['comprehension'];
    $langReading = $_POST['reading'];
    $langWriting = $_POST['writing'];
    $bCategory = '';
    $aCategory = '';
    $cCategory = '';
    if(isset($_POST['bCategory'])) {
        $bCategory = 'B';
    }
    if(isset($_POST['aCategory'])) {
        $aCategory = 'A';
    }
    if(isset($_POST['cCategory'])) {
        $cCategory = 'C';
    }
// need to add email check
    if(!preg_match('/[^A-Za-z]/', $firstName) && !preg_match('/[^A-Za-z]/', $lastName)
        && !preg_match('/[^A-Za-z0-9 ]/', $companyName) && strlen($firstName) <= 20 && strlen($firstName) >= 2 &&
        strlen($lastName) <= 20 && strlen($lastName) >= 2 && strlen($companyName) <= 20 && strlen($companyName) >= 2
        && !preg_match('/[^0-9\+\-\s]/', $phoneNum)) {
        $personalInfoTable = '<table><thead><tr><th colspan="2">Personal Information</th></tr></thead><tbody>' .
            '<tr><td>First Name</td><td>' . $firstName . '</td></tr><td>Last Name</td><td>' . $lastName . '</td></tr>' .
            '<tr><td>Email</td><td>' . $email . '</td></tr>' .
            '<tr><td>Phone</td><td>' . $phoneNum . '</td></tr>' .
            '<tr><td>Gender</td><td>' . $sex . '</td></tr>' .
            '<tr><td>Birth Date</td><td>' . $birthDate . '</td></tr>' .
            '<tr><td>Nationality</td><td>' . $nationality . '</td></tr></tbody></table>';
        $lastWorkTable = '<table><thead><tr><th colspan="2">Last Work Position</th></tr></thead><tbody>' .
            '<tr><td>Company Name</td><td>' . $companyName . '</td></tr>' .
            '<tr><td>From</td><td>' . $fromDate . '</td></tr>' .
            '<tr><td>To</td><td>' . $toDate . '</td></tr></tbody></table>';
        $computerSkillsTable = '<table><thead><tr><th colspan="2">Computer Skills</th></tr></thead><tbody>' .
            '<tr><td>Programming Languages</td><td><table><thead><tr><th>Language</th><th>Skill Level</th></tr></thead>' .
            '<tbody>';
        for($i = 0; $i < count($levelProgLang) ;$i++) {
            $computerSkillsTable .= '<tr>';
            $computerSkillsTable .= '<td>' . htmlentities($programmingLanguage[$i]) . '</td>';
            $computerSkillsTable .= '<td>' . $levelProgLang[$i] . '</td>';
            $computerSkillsTable .= '</tr>';
        }
        $computerSkillsTable .= '</tbody></table></tr></tbody></table>';
        $otherSkills = '<table><thead><tr><th colspan="2">Other Skills</th></tr></thead><tbody>' .
            '<tr><td>Languages</td><td><table><thead><tr><th>Language</th><th>Comprehension</th>' .
            '<th>Reading</th><th>Writing</th></tr></thead>';
        for($i = 0; $i < count($language) ;$i++) {
            $otherSkills .= '<tr>';
            $otherSkills .= '<td>' . htmlentities($language[$i]) . '</td>';
            $otherSkills .= '<td>' . $langComprehension[$i] . '</td>';
            $otherSkills .= '<td>' . $langReading[$i] . '</td>';
            $otherSkills .= '<td>' . $langWriting[$i] . '</td>';
        }
        $otherSkills .= '</tbody></table></tr><tr><td>Driver`s License</td><td>' . $bCategory . " ". $aCategory. "" . $cCategory .'</td></tr>';
        $otherSkills .= '</tbody></table>';
    }
    echo '<section>';
    echo '<h1>CV</h1>';
    echo $personalInfoTable;
    echo $lastWorkTable;
    echo $computerSkillsTable;
    echo $otherSkills;
    echo '</section>';
}
?>
</body>
</html>