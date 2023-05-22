const express = require('express');
const mysql = require('mysql');
const multer = require('multer');
const cors = require('cors');
const bodyParser = require('body-parser');

const app = express();
app.use(cors());
app.use(express.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());


const db = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'bhwserver',
});

db.connect((err) => {
  if (err) throw err;
  console.log('Connected to MySQL database');
});


app.get('/account', (req, res) => {
  const {username,password }= req.query;
  const query = "SELECT account_id, account_information.Name, account_role.Role_Name FROM `account_information` INNER join account_role on account_information.Role_ID=account_role.Role_Id where username=? and password=?";

  db.query(query, [username, password], (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
    } else {
      res.status(200).send(result);
    }
  });
});

// Token(ID) verification middleware
const verifyToken = (req, res, next) => {
  const token = req.headers.authorization;

  if (!token) {
    return res.status(401).send({ error: 'No token provided' });
  }
  const userId = parseInt(token); // Assuming token is the user_id
  const query = 'SELECT * FROM account_information WHERE account_id = ?';
  db.query(query, [userId], (err, results) => {
    if (err) {
      return res.status(500).send({ error: 'Error verifying token' });
    }

    if (results.length === 0) {
      return res.status(401).send({ error: 'Invalid token' });
    }
    next();
  });
};

app.get('/bhwserver', verifyToken, (req, res) => {
  const displayData = req.query.displayData; 
  let sqlQuery;
  if (displayData === "Max ID") {
    sqlQuery = "SELECT MAX(Resident_ID) as max from resident_profile";
  } else if (displayData === "Account Role") {
    sqlQuery = "SELECT `Role_Id` as RoleId, `Role_Name` as RoleName FROM `account_role`";
  } else if (displayData === "Resident Profile") {
    sqlQuery = "SELECT Resident_ID, `Household_Number` as 'Household Number', `Family_Number` as 'Family Number', `First_Name` as 'First Name', `Middle_Name` as 'Middle Name', `Last_Name` as 'Last Name', `Extension_Name` as 'Extension Name', Date_Format(Birth_Date, '%d-%m-%Y') as 'Birth Date', `Age`, `Birth_Place` as 'Birth Place', `Civil_Status` as 'Civil Status', `Sex`, `Contact_Number` as 'Contact Number', `Purok` FROM `resident_profile`";
  } else if (displayData === "Account Request") {
    sqlQuery = "SELECT account_request.Request_ID, account_request.Name, account_request.Username, Date_Format(account_request.Date_Created, '%d-%m-%Y') as 'Date Created', account_role.Role_Name FROM `account_request` inner join Account_role on Account_role.Role_id=account_request.Role_id";
  } else if (displayData === "Beneficiaries") {
    sqlQuery = "SELECT `Beneficiary_ID`,concat(resident_profile.First_Name,' ',resident_profile.Middle_Name,' ',resident_profile.Last_Name,' ',resident_profile.Extension_Name) as Name, resident_profile.Age, resident_profile.Purok, benefits.Benefit_Name,benefits.Description, Date_Format(`Membership_Date`, '%d-%m-%Y') as 'Membership Date', `Status` FROM `beneficiary` INNER join resident_profile on resident_profile.Resident_ID=beneficiary.Resident_ID INNER join benefits on benefits.Benefit_ID=beneficiary.Benefit_ID";
  } else if (displayData === "Benefits") {
    sqlQuery = "SELECT `Benefit_ID`, `Benefit_Name` as 'Benefit Name', `Description`, Date_Format(Date_Implemented, '%d-%m-%Y') 'Date Implemented' FROM `benefits`";
  } else if (displayData === "BMI") {
    sqlQuery = "SELECT resident_profile.Resident_ID,CONCAT(First_Name,' ', Middle_Name,' ',Last_Name,' ',Extension_Name) AS Name,bmi_information.Height,bmi_information.Weight,  Status,Age, Purok,Date_Format(date_updated, '%d-%m-%Y') as 'Date Updated' FROM resident_profile inner join bmi_information on bmi_information.Resident_ID=resident_profile.Resident_ID;";
  } else if (displayData === "Blood Pressure") {
    sqlQuery = "SELECT BP_ID,concat(resident_profile.First_Name,' ',resident_profile.Middle_Name,' ',resident_profile.Last_Name,' ',resident_profile.Extension_Name) as Name, resident_profile.Age, resident_profile.Purok, resident_profile.Sex, concat(systolic,'/',diastolic) as 'Blood Pressure',Level, Date_Format(Date_Checked, '%d-%m-%Y') as 'Date Checked' FROM blood_pressure INNER join resident_profile on resident_profile.Resident_ID=blood_pressure.Resident_ID ";
  } else if (displayData === "Immunization") {
    sqlQuery = "SELECT resident_profile.`Resident_ID`, `Household_Number` as 'Household_Number', `Family_Number` as 'Family Number', concat (`First_Name`,' ', `Middle_Name`,' ', `Last_Name`, ' ',`Extension_Name`) as Name, `Birth_Date`,`Sex`,`Purok`, Date_Format(immunization.Date_Checked, '%d-%m-%Y') as 'Date Last Checked' FROM `resident_profile` inner join immunization on immunization.Resident_ID=resident_profile.Resident_ID";
  } else if (displayData === "Pregnant") {
    sqlQuery = "SELECT Pregnancy_ID,concat(resident_profile.First_Name,' ',resident_profile.Middle_Name,' ',resident_profile.Last_Name,' ',resident_profile.Extension_Name) as Name, resident_profile.Age, resident_profile.Purok,pregnancy_information.Months_of_Pregnancy, Date_Format(Date_Checked, '%d-%m-%Y') as 'Date Checked'FROM pregnancy_information INNER join resident_profile on resident_profile.Resident_ID=pregnancy_information.Resident_ID";
  }else if (displayData === "Not Pregnant") {
    sqlQuery = "SELECT Resident_ID,concat(First_Name, ' ', Middle_Name, ' ', Last_Name, ' ', Extension_Name) as Name, Age, Purok from resident_profile where Resident_ID not in (SELECT Resident_ID from pregnancy_information) and sex='Female'";
  } else if (displayData === "Vaccine") {
    sqlQuery = "SELECT `Vaccine_ID`, `Vaccine_Name` as 'Vaccine Name', `Vaccine_Detail` as 'Detail', `Dossage_Sequence` as 'Dossage Sequence',  Date_Format(Date_Implemented, '%d-%m-%Y') 'Date Implemented'  FROM `vaccine`";
  } else if (displayData === "Vaccinated") {
    sqlQuery = "SELECT vaccination.Vaccination_ID,concat( `First_Name`,' ', `Middle_Name`, ' ',`Last_Name`,' ', `Extension_Name`) as Name, `Age`, `Sex`, `Purok`,vaccine.Vaccine_Name as 'Vaccine Name',vaccine.Dossage_Sequence as 'Dossage Sequence',vaccination.Vaccination_Count as 'Dossage Complete',vaccination.Status,vaccination.Vaccination_Date as 'Vaccination Date'  FROM `resident_profile` INNER join vaccination on vaccination.Resident_ID=resident_profile.Resident_ID inner join vaccine on vaccine.Vaccine_ID=vaccination.Vaccine_ID";
  }else if (displayData === "Not Vaccinated") {
    sqlQuery = "SELECT vaccination.Vaccination_ID,concat( `First_Name`,' ', `Middle_Name`, ' ',`Last_Name`,' ', `Extension_Name`) as Name, `Age`, `Sex`, `Purok`,vaccine.Vaccine_Name as 'Vaccine Name',vaccine.Dossage_Sequence as 'Dossage Sequence',vaccination.Vaccination_Count as 'Dossage Complete',vaccination.Status,vaccination.Vaccination_Date as 'Vaccination Date'  FROM `resident_profile` INNER join vaccination on vaccination.Resident_ID=resident_profile.Resident_ID inner join vaccine on vaccine.Vaccine_ID=vaccination.Vaccine_ID";
  }else if (displayData === "Non-beneficiaries") {
    sqlQuery = "SELECT Resident_ID,concat(First_Name, ' ', Middle_Name, ' ', Last_Name, ' ', Extension_Name) as Name, Age, Purok from resident_profile where Resident_ID not in (SELECT Resident_ID from beneficiary)";
  } else if (displayData === "General Report") {
    sqlQuery = "SELECT rp.Purok, " +
    "SUM(CASE WHEN rp.Sex='Male' THEN 1 ELSE 0 END) AS Male, " +
    "SUM(CASE WHEN rp.Sex='Female' THEN 1 ELSE 0 END) AS Female, " +
    "SUM(CASE WHEN vr.status='Completed' THEN 1 ELSE 0 END) AS Vaccinated, " +
    "SUM(CASE WHEN pr.Resident_ID IS NOT NULL THEN 1 ELSE 0 END) AS Pregnant, " +
    "SUM(CASE WHEN bp.level != 'Normal' THEN 1 ELSE 0 END) AS 'Not Normal BP', " +
    "SUM(CASE WHEN TIMESTAMPDIFF(YEAR, rp.Birth_Date, CURDATE()) < 3 THEN 1 ELSE 0 END) AS 'Below 3 Years Old', " +
    "SUM(CASE WHEN bmi.Status != 'Normal' THEN 1 ELSE 0 END) AS 'Not Normal BMI' " +
    "FROM resident_profile rp " +
    "LEFT JOIN vaccination vr ON rp.Resident_ID = vr.Resident_ID " +
    "LEFT JOIN pregnancy_information pr ON rp.Resident_ID = pr.Resident_ID " +
    "LEFT JOIN blood_pressure bp ON rp.Resident_ID = bp.Resident_ID " +
    "LEFT JOIN bmi_information bmi ON rp.Resident_ID = bmi.Resident_ID " +
    "GROUP BY rp.Purok;";
  } else if (displayData === "AutoUpdate") {
    sqlQuery="Update resident_profile set age=date_format(from_days(datediff(now(),birth_date)),'%Y');"+
                    "INSERT INTO immunization (resident_id) SELECT resident_profile.resident_id FROM resident_profile WHERE resident_profile.Birth_Date >= DATE_SUB(CURDATE(), INTERVAL 3 YEAR) AND NOT EXISTS( SELECT 1 FROM immunization WHERE immunization.resident_id = resident_profile.resident_id);"+
                    "DELETE FROM immunization WHERE resident_id IN (SELECT resident_id FROM resident_profile WHERE birth_date <= DATE_SUB(CURDATE(), INTERVAL 3 YEAR));";
  } else {
    return res.status(400).send({ error: 'Invalid displayData value' });
  }
  db.query(sqlQuery, (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
    } else {
      res.status(200).send(result);
    }
  });
  
});

app.get('/search', verifyToken, (req, res) => {
  let {displayData,searchData}=req.query;
  
  let sqlQuery;
  if (displayData === "Resident by Sex") {
    sqlQuery = "SELECT Resident_ID, `Household_Number` as 'Household Number', `Family_Number` as 'Family Number', `First_Name` as 'First Name', `Middle_Name` as 'Middle Name', `Last_Name` as 'Last Name', `Extension_Name` as 'Extension Name', Date_Format(Birth_Date, '%d-%m-%Y') as 'Birth Date', `Age`, `Birth_Place` as 'Birth Place', `Civil_Status` as 'Civil Status', `Sex`, `Contact_Number` as 'Contact Number', `Purok` FROM `resident_profile` where sex = ?";
  } 
  else if (displayData === "Resident by Purok") {
    sqlQuery = "SELECT Resident_ID, `Household_Number` as 'Household Number', `Family_Number` as 'Family Number', `First_Name` as 'First Name', `Middle_Name` as 'Middle Name', `Last_Name` as 'Last Name', `Extension_Name` as 'Extension Name', Date_Format(Birth_Date, '%d-%m-%Y') as 'Birth Date', `Age`, `Birth_Place` as 'Birth Place', `Civil_Status` as 'Civil Status', `Sex`, `Contact_Number` as 'Contact Number', `Purok` FROM `resident_profile` where Purok = ?";
  } else if (displayData === "Search Resident") {
    searchData=searchData+"%";
    sqlQuery = "SELECT Resident_ID, `Household_Number` as 'Household Number', `Family_Number` as 'Family Number', `First_Name` as 'First Name', `Middle_Name` as 'Middle Name', `Last_Name` as 'Last Name', `Extension_Name` as 'Extension Name', Date_Format(Birth_Date, '%d-%m-%Y') as 'Birth Date', `Age`, `Birth_Place` as 'Birth Place', `Civil_Status` as 'Civil Status', `Sex`, `Contact_Number` as 'Contact Number', `Purok` FROM `resident_profile` where First_Name like ? ";
  } 
  else if (displayData === "Search Non-beneficiaries") {
    searchData=searchData+"%";
    sqlQuery = "SELECT Resident_ID,concat(First_Name, ' ', Middle_Name, ' ', Last_Name, ' ', Extension_Name) as Name, Age, Purok from resident_profile where Resident_ID not in (SELECT Resident_ID from beneficiary) and First_Name like ?";
  } 
  else if (displayData === "Search Mem-beneficiaries") {
    searchData=searchData+"%";
    sqlQuery = "SELECT `Beneficiary_ID`,concat(resident_profile.First_Name,' ',resident_profile.Middle_Name,' ',resident_profile.Last_Name,' ',resident_profile.Extension_Name) as Name, resident_profile.Age, resident_profile.Purok, benefits.Benefit_Name, benefits.Description, Date_Format(`Membership_Date`, '%d-%m-%Y') as 'Membership Date', `Status` FROM `beneficiary` INNER join resident_profile on resident_profile.Resident_ID=beneficiary.Resident_ID INNER join benefits on benefits.Benefit_ID=beneficiary.Benefit_ID where First_Name like ? ";
  } 
  else if (displayData === "Search Benefits") {
    searchData=searchData+"%";
    sqlQuery = "SELECT `Benefit_ID`, `Benefit_Name` as 'Benefit Name', `Description`, Date_Format(Date_Implemented, '%d-%m-%Y') 'Date Implemented' FROM `benefits` where Benefit_Name like ? ";
  } 
  else if (displayData === "Search Benefits Id") {
    sqlQuery = "SELECT `Description` FROM `benefits` WHERE Benefit_ID=?";
  } 
  else if (displayData === "BMI Status") {
    sqlQuery = "SELECT resident_profile.Resident_ID,CONCAT(First_Name,' ', Middle_Name,' ',Last_Name,' ',Extension_Name) AS Name,bmi_information.Height,bmi_information.Weight,  Status,Age, Purok,Date_Format(date_updated, '%d-%m-%Y') as 'Date Updated' FROM resident_profile inner join bmi_information on bmi_information.Resident_ID=resident_profile.Resident_ID where Status=?;";
  }
  else if (displayData === "Search BMI") {
    searchData=searchData+"%";
    sqlQuery = "SELECT resident_profile.Resident_ID,CONCAT(First_Name,' ', Middle_Name,' ',Last_Name,' ',Extension_Name) AS Name,bmi_information.Height,bmi_information.Weight,  Status,Age, Purok,Date_Format(date_updated, '%d-%m-%Y') as 'Date Updated' FROM resident_profile inner join bmi_information on bmi_information.Resident_ID=resident_profile.Resident_ID where First_Name like ?;";
  } 
  else if (displayData === "Blood Pressure Normal") {
    sqlQuery = "SELECT BP_ID,concat(resident_profile.First_Name,' ',resident_profile.Middle_Name,' ',resident_profile.Last_Name,' ',resident_profile.Extension_Name) as Name, resident_profile.Age, resident_profile.Purok, resident_profile.Sex, concat(systolic,'/',diastolic) as 'Blood Pressure',Level, Date_Format(Date_Checked, '%d-%m-%Y') as 'Date Checked' FROM blood_pressure INNER join resident_profile on resident_profile.Resident_ID=blood_pressure.Resident_ID where Level =?";
  }
  else if (displayData === "Blood Pressure Not Normal") {
    sqlQuery = "SELECT BP_ID,concat(resident_profile.First_Name,' ',resident_profile.Middle_Name,' ',resident_profile.Last_Name,' ',resident_profile.Extension_Name) as Name, resident_profile.Age, resident_profile.Purok, resident_profile.Sex, concat(systolic,'/',diastolic) as 'Blood Pressure',Level, Date_Format(Date_Checked, '%d-%m-%Y') as 'Date Checked' FROM blood_pressure INNER join resident_profile on resident_profile.Resident_ID=blood_pressure.Resident_ID where Level !=?";
  }
  else if (displayData === "Search Blood Pressure") {
    searchData=searchData+"%";
    sqlQuery = "SELECT BP_ID,concat(resident_profile.First_Name,' ',resident_profile.Middle_Name,' ',resident_profile.Last_Name,' ',resident_profile.Extension_Name) as Name, resident_profile.Age, resident_profile.Purok, resident_profile.Sex, concat(systolic,'/',diastolic) as 'Blood Pressure',Level, Date_Format(Date_Checked, '%d-%m-%Y') as 'Date Checked' FROM blood_pressure INNER join resident_profile on resident_profile.Resident_ID=blood_pressure.Resident_ID where resident_profile.First_Name like ?";
  }
  else if (displayData === "Search Immunization") {
    searchData=searchData+"%";
    sqlQuery = "SELECT resident_profile.`Resident_ID`, `Household_Number` as 'Household_Number', `Family_Number` as 'Family Number', concat (`First_Name`,' ', `Middle_Name`,' ', `Last_Name`, ' ',`Extension_Name`) as Name, `Birth_Date`,`Sex`,`Purok`, Date_Format(immunization.Date_Checked, '%d-%m-%Y') as 'Date Last Checked' FROM `resident_profile` inner join immunization on immunization.Resident_ID=resident_profile.Resident_ID where First_Name like ?";
  } 
  else if (displayData === "Search Non-pregnant") {
    searchData=searchData+"%";
    sqlQuery = "SELECT Resident_ID,concat(First_Name, ' ', Middle_Name, ' ', Last_Name, ' ', Extension_Name) as Name, Age, Purok from resident_profile where Resident_ID not in (SELECT Resident_ID from pregnancy_information) and sex='Female' and First_Name like ? ";
  } 
  else if (displayData === "Search Pregnant") {
    searchData=searchData+"%";
    sqlQuery = "SELECT Pregnancy_ID,concat(resident_profile.First_Name,' ',resident_profile.Middle_Name,' ',resident_profile.Last_Name,' ',resident_profile.Extension_Name) as Name, resident_profile.Age, resident_profile.Purok,pregnancy_information.Months_of_Pregnancy, Date_Format(Date_Checked, '%d-%m-%Y') as 'Date Checked'FROM pregnancy_information INNER join resident_profile on resident_profile.Resident_ID=pregnancy_information.Resident_ID where First_Name like ?";
  } 
  else if (displayData === "Search Vaccine") {
    searchData=searchData+"%";
    sqlQuery = "SELECT `Vaccine_ID`, `Vaccine_Name` as 'Vaccine Name', `Vaccine_Detail` as 'Detail', `Dossage_Sequence` as 'Dossage Sequence',  Date_Format(Date_Implemented, '%d-%m-%Y') 'Date Implemented'  FROM `vaccine` where Vaccine_Name like ?";
  } 
  else if (displayData === "Search Vaccine Id") {
    sqlQuery = "SELECT Dossage_Sequence FROM `vaccine` WHERE Vaccine_ID=?";
  } 
  else if (displayData === "Search Vaccination") {
    searchData=searchData+"%";
    sqlQuery = "SELECT vaccination.Vaccination_ID,concat( `First_Name`,' ', `Middle_Name`, ' ',`Last_Name`,' ', `Extension_Name`) as Name, `Age`, `Sex`, `Purok`,vaccine.Vaccine_Name as 'Vaccine Name',vaccine.Dossage_Sequence as 'Dossage Sequence',vaccination.Vaccination_Count as 'Dossage Complete',vaccination.Status,vaccination.Vaccination_Date as 'Vaccination Date'  FROM `resident_profile` INNER join vaccination on vaccination.Resident_ID=resident_profile.Resident_ID inner join vaccine on vaccine.Vaccine_ID=vaccination.Vaccine_ID where First_Name like ?";
  } 
  else if (displayData === "Not Vaccinated") {
    sqlQuery = "SELECT Resident_ID,concat(First_Name, ' ', Middle_Name, ' ', Last_Name, ' ', Extension_Name) as Name, Age,Sex, Purok from resident_profile where Resident_ID not in (SELECT Resident_ID from vaccination)";
  } 
  else {
    return res.status(400).send({ error: 'Invalid displayData value' });
  }
  db.query(sqlQuery,[searchData], (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
    } else {
      res.status(200).send(result);
    }
  });
});

app.delete('/bhwserver', verifyToken, (req, res) => {
  const {id,tableName}= req.query;
  let sqlQuery;
  if (!id || isNaN(id) || !tableName) {
    res.status(400).send({ error: 'Invalid or missing Parameter' });
    return;
  }
  if(tableName==="Resident Profile"){
    sqlQuery = "DELETE FROM `resident_profile` WHERE Resident_ID = ?";
  }
  else if(tableName==="Account Request"){
    sqlQuery = "DELETE FROM `account_request` WHERE Request_ID=?";
  }
  else if(tableName==="Beneficiary Resident"){
    sqlQuery = "DELETE FROM `beneficiary` WHERE Resident_ID=?";
  }
  else if(tableName==="Beneficiary"){
    sqlQuery = "DELETE FROM `beneficiary` WHERE Beneficiary_ID=?";
  }
  else if(tableName==="Benefits"){
    sqlQuery = "DELETE FROM `benefits` WHERE Benefit_ID=?";
  }
  else if(tableName==="Blood Pressure"){
    sqlQuery = "DELETE FROM `blood_pressure` WHERE Resident_ID=?";
  }
  else if(tableName==="BMI"){
    sqlQuery = "DELETE FROM `bmi_information` WHERE Resident_ID=?";
  }
  /*else if(tableName==="Immunization Resident"){
    sqlQuery = "DELETE FROM `immunization` WHERE Resident_ID=?";
  }*/
  else if(tableName==="Pregnant Resident"){
    sqlQuery = "DELETE FROM `pregnancy_information` WHERE Resident_ID=?";
  }
  else if(tableName==="Pregnant"){
    sqlQuery = "DELETE FROM `pregnancy_information` WHERE Pregnancy_ID=?";
  }
  else if(tableName==="Vaccination Resident"){
    sqlQuery = "DELETE FROM `vaccination` WHERE Resident_ID=?";
  }
  else if(tableName==="Vaccination"){
    sqlQuery = "DELETE FROM `vaccination` WHERE Vaccination_ID=?";
  }
  else if(tableName==="Vaccine"){
    sqlQuery = "DELETE FROM `vaccine` WHERE Vaccine_ID=?";
  }
  else {
    return res.status(400).send({ error: 'Invalid table name' });
  }
  db.query(sqlQuery, [id], (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error' });
    } else {
      res.status(200).send({ message: 'Successfully deleted' });
    }
  });
});

app.put('/bhwserver', verifyToken, (req, res) => {
  const id=req.query.id;
  const tableName=req.query.tableName;

  if ( !id || isNaN(id) || !tableName) {
    res.status(400).send({ error: "Missing parameter or id error" });
    return;
  }

  if(tableName==="Resident Profile"){
    const {householdNumber,familyNumber,firstName,middleName,lastName,extensionName,birthDate,Age,birthPlace,civilStatus,sex,contactNumber,purok} = req.query;
    if (!householdNumber || !familyNumber || !firstName || !middleName || !lastName || !birthDate || !Age || !birthPlace || !civilStatus || !civilStatus || !sex || !purok) {
      res.status(400).send({ error: "Missing parameter" });
      return;
    }
    const query = "UPDATE `resident_profile` SET `Household_Number`= ? ,`Family_Number`= ? ,`First_Name`= ? ,`Middle_Name`= ? ,`Last_Name`= ? ,`Extension_Name`= ? ,`Birth_Date`= ? ,`Age`= ? ,`Birth_Place`= ? ,`Civil_Status`= ? ,`Sex`= ? ,`Contact_Number`= ? ,`Purok`= ? WHERE resident_id= ?";
    db.query(query, [householdNumber, familyNumber,firstName,middleName,lastName,extensionName,birthDate,Age,birthPlace,civilStatus,sex,contactNumber,purok,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Beneficiaries"){
    const {benefitId,membershipDate,status} = req.query;
    if ( !benefitId || isNaN(benefitId) || !membershipDate || !status) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `beneficiary` SET `Benefit_ID`=?,`Membership_Date`=?,`Status`= ? WHERE Beneficiary_ID= ?";
    db.query(query, [benefitId,membershipDate,status,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Benefits"){
    const {benefitName,description,dateImplemented} = req.query;
    if (!benefitName || !description || !dateImplemented) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `benefits` SET `Benefit_Name`= ?,`Description`= ?,`Date_Implemented`= ? WHERE Benefit_ID= ?";
    db.query(query, [benefitName,description,dateImplemented,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Blood Pressure"){
    const {systolic,diastolic,level,dateChecked} = req.query;
    if (!systolic || isNaN(systolic) || !diastolic || isNaN(diastolic) || !level || !dateChecked) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `blood_pressure` SET `systolic`= ?,`diastolic`= ?,`Level`= ?,`Date_Checked`= ? WHERE BP_ID= ?";
    db.query(query, [systolic,diastolic,level,dateChecked,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="BMI"){
    const {weight,height,status,dateUpdated} = req.query;
    if (!weight || isNaN(weight) || !height || isNaN(height) || !status || !dateUpdated ) {
      res.status(400).send({ error: "Missing parameter or error" });
      return;
    }
    const query = "UPDATE `bmi_information` SET `Weight`=?,`Height`=?,`Status`=?,`date_updated`=? where Resident_ID=?";
    db.query(query, [weight,height,status,dateUpdated,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Pregnancy"){
    const {monthsOfPregnancy,dateChecked} = req.query;
    if (!monthsOfPregnancy || isNaN(monthsOfPregnancy) || !dateChecked) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `pregnancy_information` SET `Months_of_Pregnancy`= ?,`Date_Checked`= ? WHERE Pregnancy_ID=?";
    db.query(query, [monthsOfPregnancy,dateChecked,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Vaccine"){
    const {vaccineName,vaccineDetail,dossageSequence,dateImplemented} = req.query;
    if (!vaccineName || isNaN(dossageSequence) || !vaccineDetail || !dateImplemented) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `vaccine` SET `Vaccine_Name`=?,`Vaccine_Detail`=?,`Dossage_Sequence`=?,`Date_Implemented`=? WHERE Vaccine_ID=?";
    db.query(query, [vaccineName,vaccineDetail,dossageSequence,dateImplemented,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Vaccination"){
    const {vaccinationDate,vaccineId,vaccinationCount,status} = req.query;
    if (!vaccinationDate || isNaN(vaccineId) || !vaccineId || !vaccinationCount || isNaN(vaccinationCount) || !status) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `vaccination` SET `Vaccination_Date`=?,`Vaccine_ID`=?,`Vaccination_Count`=?,`Status`=? WHERE Vaccination_ID =?";
    db.query(query, [vaccinationDate,vaccineId,vaccinationCount,status,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else{
    return res.status(400).send({ error: 'Invalid table name' });
  }
});

app.post('/bhwserver', verifyToken, (req, res) => {
  const tableName=req.query.tableName;
  console.log(tableName);
  if(tableName==="Resident Profile"){
    const {residentId,householdNumber,familyNumber,firstName,middleName,lastName,extensionName,birthDate,Age,birthPlace,civilStatus,sex,contactNumber,purok} = req.query;
    console.log(req.query);
    if (!householdNumber || !familyNumber || !firstName || !middleName || !lastName || !birthDate || !Age || !birthPlace || !civilStatus || !civilStatus || !sex || !purok) {
      res.status(400).send({ error: "Missing parameter" });
      return;
    }
    const query = "INSERT INTO `resident_profile`VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
    db.query(query, [residentId,householdNumber, familyNumber,firstName,middleName,lastName,extensionName,birthDate,Age,birthPlace,civilStatus,sex,contactNumber,purok], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Account Information"){
    const {accountId} = req.query;
    if (!accountId || isNaN(accountId)) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT into account_information(`Name`, `Username`, `Password`, `Date_Created`, `Role_ID`) SELECT `Name`, `Username`, `Password`, `Date_Created`, `Role_ID`  FROM account_request WHERE Request_ID=?";
    db.query(query, [accountId], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Account Request"){
    const {name,username,password,dateCreated,roleId} = req.query;
    if (!name || !username || !password || !dateCreated || !roleId || isNaN(roleId)) {
      res.status(400).send({ error: "Missing parameter or role id error" });
      return;
    }
    const query = "INSERT INTO `account_request`(`Name`, `Username`, `Password`, `Date_Created`, `Role_ID`) VALUES (?,?,?,?,?)";
    db.query(query, [name,username,password,dateCreated,roleId], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Beneficiaries"){
    const {residentId,benefitId,membershipDate,status} = req.query;
    if (!residentId || isNaN(residentId) || !benefitId || isNaN(benefitId) || !membershipDate || !status) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `beneficiary`(`Resident_ID`, `Benefit_ID`, `Membership_Date`, `Status`) VALUES (?,?,?,?)";
    db.query(query, [residentId,benefitId,membershipDate,status], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Benefits"){
    const {benefitName,description,dateImplemented} = req.query;
    if (!benefitName || !description || !dateImplemented) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `benefits`(`Benefit_Name`,`Description`, `Date_Implemented`) VALUES (?,?,?)";
    db.query(query, [benefitName,description,dateImplemented], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Blood Pressure"){
    const {residentId} = req.query;
    if (!residentId || isNaN(residentId)) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `blood_pressure`(`Resident_ID`) VALUES (?)";
    db.query(query, [residentId], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="BMI"){
    const {residentId} = req.query;
    if (!residentId || isNaN(residentId)) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `bmi_information`(`Resident_ID`) VALUES(?)";
    db.query(query, [residentId], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Pregnancy"){
    const {residentId,monthsOfPregnancy,dateChecked} = req.query;
    if (!residentId || isNaN(residentId) || !monthsOfPregnancy || isNaN(monthsOfPregnancy) || !dateChecked) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `pregnancy_information`(`Resident_ID`, `Months_of_Pregnancy`, `Date_Checked`) VALUES (?,?,?)";
    db.query(query, [residentId,monthsOfPregnancy,dateChecked], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Vaccine"){
    const {vaccineName,vaccineDetail,dossageSequence,dateImplemented} = req.query;
    if (!vaccineName || isNaN(dossageSequence) || !vaccineDetail || !dateImplemented) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `vaccine`( `Vaccine_Name`, `Vaccine_Detail`, `Dossage_Sequence`, `Date_Implemented`) VALUES (?,?,?,?)";
    db.query(query, [vaccineName,vaccineDetail,dossageSequence,dateImplemented], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else if(tableName==="Vaccination"){
    const {residentId,vaccinationDate,vaccineId,vaccinationCount,status} = req.query;
    if (!residentId || isNaN(residentId) || !vaccinationDate || isNaN(vaccineId) || !vaccineId || !vaccinationCount || isNaN(vaccinationCount) || !status) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "INSERT INTO `vaccination`( `Resident_ID`, `Vaccination_Date`, `Vaccine_ID`, `Vaccination_Count`, `Status`) VALUES (?,?,?,?,?)";
    db.query(query, [residentId,vaccinationDate,vaccineId,vaccinationCount,status], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  }
  else{
    return res.status(400).send({ error: 'Invalid table name' });
  }
});

app.listen(3000, () => {
  console.log('Server running on port 3000');
});
