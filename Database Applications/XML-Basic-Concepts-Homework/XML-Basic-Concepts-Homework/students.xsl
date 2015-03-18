<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h2>Students</h2>
        <table>
          <tr>
            <th>Name</th>
            <th>Gender</th>
            <th>Birth Date</th>
            <th>Phone Number</th>
            <th>Email</th>
            <th>University</th>
            <th>Speciality</th>
            <th>Faculty Number</th>
            <th>Exam Name</th>
            <th>Date Taken</th>
            <th>Grade</th>
          </tr>
          <xsl:for-each select="/students/student">
            <tr>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="gender"/>
              </td>
              <td>
                <xsl:value-of select="birth-date"/>
              </td>
              <td>
                <xsl:value-of select="phone-number"/>
              </td>
              <td>
                <xsl:value-of select="email"/>
              </td>
              <td>
                <xsl:value-of select="university"/>
              </td>
              <td>
                <xsl:value-of select="speciality"/>
              </td>
              <td>
                <xsl:value-of select="faculty-number"/>
              </td>
              <td>
                <xsl:value-of select="exams/exam-name"/>
              </td>
              <td>
                <xsl:value-of select="exams/date-taken"/>
              </td>
              <td>
                <xsl:value-of select="exams/grade"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>