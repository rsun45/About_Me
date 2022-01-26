#ifndef TEST_H
#define TEST_H


#include <QtTest/QtTest>

class TestCases: public QObject
{
    Q_OBJECT

private slots:

    void testReadList_Fail();
    void testReadList_Pass();
    void testQuotedData_Fail();
    void testQuotedData_Pass();
    void testDateRange_Fail();
    void testDateRange_Pass();
    void testFindRecord_Fail();
    void testFindRecord_Pass();
    void testMandatoryFields_Fail();
    void testMandatoryFields_Pass();
    void testTeachHeaders();
    void testPubsHeaders();
    void testPresHeaders();
    void testGrantsHeaders();
    void testSearch_Fail();
    void testSearch_Pass();

};

#endif // TEST_H
