#include "test/test.h"
#include "database/RecordsManager.h"
#include "database/CSVReader.h"
#include "database/QSortListIO.h"
#include "gui/mainwindow.h"


//This test should FAIL
void TestCases::testReadList_Fail() {
     QSortListIO testSort2("testsortlist2.dat");
     QList<QStringList> testSortFields2;
     QStringList theAnswer2;
     theAnswer2 << "Aaron" << "Leung";
     QList<QStringList> theRealAnswer2;
     theRealAnswer2 << theAnswer2;
     testSort2.saveList(theRealAnswer2);
     testSortFields2 = testSort2.readList();

     theRealAnswer2.pop_back();
     QVERIFY(testSortFields2 == theRealAnswer2);
}

void TestCases::testReadList_Pass()
{
    QSortListIO testSort("testsortlist.dat");

    QList<QStringList> testSortFields;


    QStringList theAnswer;
    theAnswer << "Aaron" << "Leung";
    QList<QStringList> theRealAnswer;
    theRealAnswer << theAnswer;

    testSort.saveList(theRealAnswer);

    testSortFields = testSort.readList();



    QVERIFY(testSortFields == theRealAnswer);
}

void TestCases::testQuotedData_Fail()
{
    // initialize a CSVReader class
    CSVReader testData;
    CSVReader testDifferentData;

    // load data
    testData.loadCSV("testData.csv");
    testDifferentData.loadCSV("testDifferentData.csv");

    std::vector<std::string> data = testData.getHeaders();
    std::vector<std::string> differentData = testDifferentData.getHeaders();

    // compare if the data with quote or not are same
    std::vector<std::string>::iterator it1  = data.begin();
    std::vector<std::string>::iterator it2  = differentData.begin();

    bool testDifferent = true;

    for (;it1 != data.end() && it2 != differentData.end(); ++it1, ++it2){
        if (*(it1) != *(it2)){
            testDifferent = false;
        }
    }
    QVERIFY(testDifferent == true);

}

void TestCases::testQuotedData_Pass()
{
    // initialize a CSVReader class
    CSVReader testData;
    CSVReader testQuotedData;

    // load data
    testData.loadCSV("testData.csv");
    testQuotedData.loadCSV("testQuotedData.csv");

    std::vector<std::string> data = testData.getHeaders();
    std::vector<std::string> quotedData = testQuotedData.getHeaders();

    // compare if the data with quote or not are same
    std::vector<std::string>::iterator it1  = data.begin();
    std::vector<std::string>::iterator it2  = quotedData.begin();

    bool testQuotes = true;

    for (;it1 != data.end() && it2 != quotedData.end(); ++it1, ++it2){
        if (*(it1) != *(it2)){
            testQuotes = false;
        }
    }
    QVERIFY(testQuotes == true);

}

void TestCases::testDateRange_Fail()
{
    // initialize a CSVReader class
    CSVReader reader;

    // load data
    reader = CSVReader("testDataRange.csv");

    std::vector<std::string> header;
    header = reader.getHeaders();
    std::vector<std::vector<std::string>> testData = reader.getData();

    RecordsManager * testdb = new RecordsManager(&header);

    // load in data into the manager, with the date as the key
    int sortHeaderIndex = testdb->getHeaderIndex("Start Date");

    for (int i = 0; i < (int) testData.size(); i++)
    {
        int yrIndex = testdb->getHeaderIndex("Start Date");
        int year;
        sscanf(testData[i][yrIndex].c_str(), "%4d", &year);
        testData[i][yrIndex] = std::to_string(year);

        testdb->addRecord(reader.parseDateString(testData[i][sortHeaderIndex]), &testData[i]);
    }

    std::vector<BasicRecord*> count = testdb->findRecordsInRange(2010,2012);

    QVERIFY(count.size()==99);

}

void TestCases::testDateRange_Pass()
{
    // initialize a CSVReader class
    CSVReader reader;

    // load data
    reader = CSVReader("testDataRange.csv");

    std::vector<std::string> header;
    header = reader.getHeaders();
    std::vector<std::vector<std::string>> testData = reader.getData();

    RecordsManager * testdb = new RecordsManager(&header);

    // load in data into the manager, with the date as the key
    int sortHeaderIndex = testdb->getHeaderIndex("Start Date");

    for (int i = 0; i < (int) testData.size(); i++)
    {
        int yrIndex = testdb->getHeaderIndex("Start Date");
        int year;
        sscanf(testData[i][yrIndex].c_str(), "%4d", &year);
        testData[i][yrIndex] = std::to_string(year);

        testdb->addRecord(reader.parseDateString(testData[i][sortHeaderIndex]), &testData[i]);
    }

    std::vector<BasicRecord*> count = testdb->findRecordsInRange(2010,2012);

    QVERIFY(count.size()==2);

}

// This one suppose to be fail
void TestCases::testFindRecord_Fail(){
    // initial a vector stores fruit column
    std::vector<std::string> FruitReturnList;
    FruitReturnList.push_back("Apple");
    FruitReturnList.push_back("Banana");
    FruitReturnList.push_back("Cherry");

    // initial a vector stores food column
    std::vector<std::string> FoodReturnList;
    FoodReturnList.push_back("Pizza");
    FoodReturnList.push_back("Burger");
    FoodReturnList.push_back("Chicken");

    // initial a vector stores fruit column
    std::vector<std::string> DrinkReturnList;
    DrinkReturnList.push_back("Pepsi");
    DrinkReturnList.push_back("Sprite");
    DrinkReturnList.push_back("Fenta");

    // initial a vector stores header row
    BasicRecord header;
    header.push_back("food");
    header.push_back("drink");
    header.push_back("fruit");

    // initial RecordsManager to add header and data into it
    RecordsManager rm(&header);
    rm.addRecord(0,&FoodReturnList);
    rm.addRecord(1,&DrinkReturnList);
    rm.addRecord(2,&FruitReturnList);

    // store the column of food to result
    std::vector<BasicRecord*> result;
    result = rm.findRecord(rm.getHeaderIndex("food"));

    // compare food column with fruit column, should be fail
    QVERIFY(FruitReturnList == *result.front());

}

// This one suppose to be pass
void TestCases::testFindRecord_Pass(){
    // initial a vector stores fruit column
    std::vector<std::string> FruitReturnList;
    FruitReturnList.push_back("Apple");
    FruitReturnList.push_back("Banana");
    FruitReturnList.push_back("Cherry");

    // initial a vector stores food column
    std::vector<std::string> FoodReturnList;
    FoodReturnList.push_back("Pizza");
    FoodReturnList.push_back("Burger");
    FoodReturnList.push_back("Chicken");

    // initial a vector stores fruit column
    std::vector<std::string> DrinkReturnList;
    DrinkReturnList.push_back("Pepsi");
    DrinkReturnList.push_back("Sprite");
    DrinkReturnList.push_back("Fenta");

    // initial a vector stores header row
    BasicRecord header;
    header.push_back("food");
    header.push_back("drink");
    header.push_back("fruit");

    // initial RecordsManager to add header and data into it
    RecordsManager rm(&header);
    rm.addRecord(0,&FoodReturnList);
    rm.addRecord(1,&DrinkReturnList);
    rm.addRecord(2,&FruitReturnList);

    // store the column of food to result
    std::vector<BasicRecord*> result;
    result = rm.findRecord(rm.getHeaderIndex("fruit"));

    // compare fruit column with fruit column, should be pass
    QVERIFY(FruitReturnList == *result.front());

}

// This test case should fail
void TestCases::testMandatoryFields_Fail() {

    std::vector<std::string> TEACH_MANFIELDS = {"Member Name", "Start Date", "Program"};
    CSVReader reader;
    std::vector<std::string> header;
    std::string searchstring;

    int sortHeaderIndex = 2;

        // create a new reader to read in the file
        reader = CSVReader("blankFields.csv");
        header = reader.getHeaders();

        // create a new manager for the data
        RecordsManager *teachdb;
        teachdb = new RecordsManager(&header);

        std::vector<std::vector<std::string>> teachData;

        // check for right file type by searching for unique header
        searchstring = "Program";
        if (std::find(header.begin(), header.end(), searchstring) != header.end()) {
            // load in data into the manager, with the date as the key
            sortHeaderIndex = teachdb->getHeaderIndex("Start Date");
            teachData = reader.getData();
            std::vector<std::vector<std::string>*> f_errs;
            unsigned int j;
            for (int i = 0; i < (int) teachData.size(); i++) {
                for (j = 0; j < TEACH_MANFIELDS.size(); j++) {
                    int index = teachdb->getHeaderIndex(TEACH_MANFIELDS[j]);
                    if (teachData[i][index].compare("") == 0) {
                        f_errs.push_back(&teachData[i]);
                        break;
                    }
                }
            }

            QVERIFY(f_errs.size() == 25);

        } else {

        }

}

// This test case should pass
void TestCases::testMandatoryFields_Pass() {

    std::vector<std::string> TEACH_MANFIELDS = {"Member Name", "Start Date", "Program"};
    CSVReader reader;
    std::vector<std::string> header;
    std::string searchstring;

    int sortHeaderIndex = 2;

        // create a new reader to read in the file
        reader = CSVReader("blankFields.csv");
        header = reader.getHeaders();

        // create a new manager for the data
        RecordsManager *teachdb;
        teachdb = new RecordsManager(&header);

        std::vector<std::vector<std::string>> teachData;

        // check for right file type by searching for unique header
        searchstring = "Program";
        if (std::find(header.begin(), header.end(), searchstring) != header.end()) {
            // load in data into the manager, with the date as the key
            sortHeaderIndex = teachdb->getHeaderIndex("Start Date");
            teachData = reader.getData();
            std::vector<std::vector<std::string>*> f_errs;
            unsigned int j;
            for (int i = 0; i < (int) teachData.size(); i++) {
                for (j = 0; j < TEACH_MANFIELDS.size(); j++) {
                    int index = teachdb->getHeaderIndex(TEACH_MANFIELDS[j]);
                    if (teachData[i][index].compare("") == 0) {
                        f_errs.push_back(&teachData[i]);
                        break;
                    }
                }
            }

            QVERIFY(f_errs.size() == 29);

        } else {

        }

}

void TestCases::testTeachHeaders(){

        std::vector<std::string> getListHeaders; // gets the list headers to get things from file(array of vectors -> pointer to an array of cectors)
        CSVReader *headerReader[1];                // reads in the headers from the file ex. publications, teachings

        headerReader[0] = new CSVReader("../Project Information/Sample Data/Teaching_sample.csv");
        getListHeaders = headerReader[0]->getHeaders();
        std::string teachHeader[] = {"Member Name", "Start Date", "Program" };
        for (int i = 0; i< 3; i++){
            QVERIFY(std::find(getListHeaders.begin(),getListHeaders.end(), teachHeader[i]) != getListHeaders.end());
        }
  }

void TestCases::testPubsHeaders(){
        std::vector<std::string> getListHeaders; // gets the list headers to get things from file(array of vectors -> pointer to an array of cectors)
        CSVReader *headerReader[1];                // reads in the headers from the file ex. publications, teachings

        headerReader[0] = new CSVReader("../Project Information/Sample Data/Publications_sample.csv");
        getListHeaders = headerReader[0]->getHeaders();
        std::string teachHeader[] = {"Member Name", "Type", "Status Date", "Role", "Title"};
        for (int i = 0; i< 5; i++){
            QVERIFY(std::find(getListHeaders.begin(),getListHeaders.end(), teachHeader[i]) != getListHeaders.end());
        }

}

void TestCases::testPresHeaders(){
        std::vector<std::string> getListHeaders; // gets the list headers to get things from file(array of vectors -> pointer to an array of cectors)
        CSVReader *headerReader[1];                // reads in the headers from the file ex. publications, teachings

        headerReader[0] = new CSVReader("../Project Information/Sample Data/Presentations_sample.csv");
        getListHeaders = headerReader[0]->getHeaders();
        std::string teachHeader[] = {"Member Name", "Date", "Type", "Role", "Title"};
        for (int i = 0; i< 5; i++){
            QVERIFY(std::find(getListHeaders.begin(),getListHeaders.end(), teachHeader[i]) != getListHeaders.end());
        }
 }

void TestCases::testGrantsHeaders(){
        std::vector<std::string> getListHeaders; // gets the list headers to get things from file(array of vectors -> pointer to an array of cectors)
        CSVReader *headerReader[1];                // reads in the headers from the file ex. publications, teachings

        headerReader[0] = new CSVReader("../Project Information/Sample Data/GrantsClinicalFunding_sample.csv");
        getListHeaders = headerReader[0]->getHeaders();
        std::string teachHeader[] = {"Member Name", "Funding Type", "Status", "Peer Reviewed?", "Role", "Title", "Start Date"};
        for (int i = 0; i< 7; i++){
            QVERIFY(std::find(getListHeaders.begin(),getListHeaders.end(), teachHeader[i]) != getListHeaders.end());
        }

}

void TestCases::testSearch_Fail()
{
    // initialize a CSVReader class
    CSVReader reader;

    // load data
    reader = CSVReader("testDataRange.csv");

    std::vector<std::string> header;
    header = reader.getHeaders();
    std::vector<std::vector<std::string>> testData = reader.getData();

    RecordsManager * testdb = new RecordsManager(&header);

    // load in data into the manager, with the date as the key
    int sortHeaderIndex = testdb->getHeaderIndex("Start Date");

    for (int i = 0; i < (int) testData.size(); i++)
    {
        int yrIndex = testdb->getHeaderIndex("Start Date");
        int year;
        sscanf(testData[i][yrIndex].c_str(), "%4d", &year);
        testData[i][yrIndex] = std::to_string(year);

        testdb->addRecord(reader.parseDateString(testData[i][sortHeaderIndex]), &testData[i]);
    }

    std::vector<BasicRecord*> count = testdb->findRecordsInRange(2010,2016, 1, "Not Included");

    QVERIFY(count.size()==2);

}

void TestCases::testSearch_Pass()
{
    // initialize a CSVReader class
    CSVReader reader;

    // load data
    reader = CSVReader("testDataRange.csv");

    std::vector<std::string> header;
    header = reader.getHeaders();
    std::vector<std::vector<std::string>> testData = reader.getData();

    RecordsManager * testdb = new RecordsManager(&header);

    // load in data into the manager, with the date as the key
    int sortHeaderIndex = testdb->getHeaderIndex("Start Date");

    for (int i = 0; i < (int) testData.size(); i++)
    {
        int yrIndex = testdb->getHeaderIndex("Start Date");
        int year;
        sscanf(testData[i][yrIndex].c_str(), "%4d", &year);
        testData[i][yrIndex] = std::to_string(year);

        testdb->addRecord(reader.parseDateString(testData[i][sortHeaderIndex]), &testData[i]);
    }

    std::vector<BasicRecord*> count = testdb->findRecordsInRange(2010,2016, 1, "Included");

    QVERIFY(count.size()==3);

}


