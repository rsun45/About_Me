#include "ui_ErrorEditDialog.h"
#include "ErrorEditDialog.h"

#include <QTableWidgetItem>
#include <QStringList>
#include <QDebug>
#include <QBrush>
#include <QColor>
#include <QAbstractButton>
#include <QMessageBox>

/*
 * Load data contained in the errors vector into a QWidgetTable
 * Fields will be marked red and editable if they are a mandatory field
 * and editable.  Otherwise all other fields will not be editable.
 * Clicking Save in the dialog will return the corrected entries to the main
 * program through the errors parameter.  If not all marked fields are edited
 * then a warning message will be displayed.  If cancel is clicked all errors
 * are discarded.
 */
ErrorEditDialog::ErrorEditDialog(QWidget *parent,
                                 std::vector<std::vector<std::string>*>& errors,
                                 std::vector<std::string>& headers,
                                 std::vector<std::string>& mandatory) :
    QDialog(parent, Qt::WindowTitleHint | Qt::WindowCloseButtonHint),
    errorList(errors),
    headerList(headers),
    mandatoryList(mandatory),
    ui(new Ui::ErrorEditDialog)
{
    ui->setupUi(this);
    ui->tableWidget->setRowCount((int) errors.size());
    ui->tableWidget->setColumnCount((int) headers.size());

    QStringList listHeaders;
    for (int i = 0; i < (int) headers.size(); i++) {
        listHeaders << headers[i].c_str();
    }

    ui->tableWidget->setHorizontalHeaderLabels(listHeaders);
    QTableWidgetItem* item;
    QBrush brush(QColor(255, 0, 0, 100));
    std::vector<std::vector<std::string>*>::iterator it;
    int row = 0;
    for (it = errors.begin(); it != errors.end(); it++) {
        for (int col = 0; col < (int) headers.size() && col < (int) (*it)->size(); col++) {
            item = new QTableWidgetItem();
            Qt::ItemFlags flag = item->flags();
            item->setFlags(Qt::ItemIsSelectable);
            item->setText((*it)->at(col).c_str());
            for (int i = 0; i < (int) mandatory.size(); i++) {
                if (mandatory[i].compare(headers.at(col)) == 0
                        && (*it)->at(col).compare("") == 0) {
                    item->setBackground(brush);
                    item->setFlags(flag);

                    std::pair<int,int> position;
                    position.first = row;
                    position.second = col;
                    itmePosition.push_back(position);

                    errorCount += 1;
                }
            }
            ui->tableWidget->setItem(row, col, item);
        }
        row++;
    }

    ui->errorLabel->setText(QString::number(errorCount));

}

//Clean up allocated memory for the table items
ErrorEditDialog::~ErrorEditDialog()
{
    for (int i = 0; i < ui->tableWidget->rowCount(); i++) {
        for (int j = 0; j < ui->tableWidget->columnCount(); j++) {
            delete ui->tableWidget->item(i,j);
        }
    }
    delete ui;
}

//Save the new data entered by the user via the error reference var
void ErrorEditDialog::saveData() {
    for (int row = 0; row < ui->tableWidget->rowCount(); row++) {
        for (int col = 0; col < ui->tableWidget->columnCount() && col < (int) errorList[row]->size(); col++) {
            std::vector<std::string>::iterator it = errorList[row]->begin()+col;
            if (errorList[row]->at(col).compare("") == 0) {
                it = errorList[row]->erase(it);
                errorList[row]->insert(it, ui->tableWidget->item(row, col)->text().toStdString());
            }
        }
    }
    accept();
}

void ErrorEditDialog::on_save_clicked()
{
    bool search = true;
    //check if mandatory fields have been filled
    for (int row = 0; row < ui->tableWidget->rowCount() && search; row++) {
        for (int j = 0; j < (int) mandatoryList.size() && search; j++) {
            std::vector<std::string>::iterator it = std::find(headerList.begin(), headerList.end(), mandatoryList[j]);
            int col = it - headerList.begin();
            QTableWidgetItem* item = ui->tableWidget->item(row, col);
            if (item->text().compare("") == 0) {
                QMessageBox::critical(this, "Error", "Mandatory fields are still empty.");
                search = false;
            }
        }
    }
    if (search) {
        saveData();
    }
}

void ErrorEditDialog::on_cancel_clicked()
{
    reject();
}

void ErrorEditDialog::on_preError_clicked()
{
    int rowLength = ui->tableWidget->rowCount();
    int columnLength = ui->tableWidget->columnCount();

    if (ui->tableWidget->currentRow() < 0 || ui->tableWidget->currentColumn() < 0){
        ui->tableWidget->item(itmePosition.front().first, itmePosition.front().second)->setSelected(true);
        ui->tableWidget->setCurrentCell(itmePosition.front().first, itmePosition.front().second);
        return;
    }

    int row = ui->tableWidget->currentRow();
    int column = ui->tableWidget->currentColumn();
    int tempRow, tempCol;

    int count = (rowLength*columnLength);

    ui->tableWidget->item(row, column)->setSelected(false);
    // check if current item has been modified
    if (ui->tableWidget->item(row, column)->text() != NULL){
        QBrush unBrush(QColor(255, 255, 255, 100));
        ui->tableWidget->item(row, column)->setBackground(unBrush);
        std::pair<int,int> p;
        p.first = row;
        p.second = column;
        itmePosition.remove(p);

        if (errorCount != 0){
            errorCount -= 1;
        }
        ui->errorLabel->setText(QString::number(errorCount));
    }

    for (int i = 1; i<=count; i++){

        if (i == 1){
            tempCol = column - 1;
            tempRow = row;
        }
        else {
            tempCol -= 1;
        }
        if (tempCol < 0){
            tempCol += columnLength;
            tempRow -= 1;
        }
        if (tempRow < 0){
            tempRow += rowLength;
        }

        for (std::list<std::pair<int,int>>::iterator it=itmePosition.begin(); it != itmePosition.end(); ++it){
            if (tempRow == (*it).first && tempCol == (*it).second){
                ui->tableWidget->item(tempRow, tempCol)->setSelected(true);
                ui->tableWidget->setCurrentCell(tempRow, tempCol);
                return;
            }
        }

    }

}

void ErrorEditDialog::on_nextError_clicked()
{

    int rowLength = ui->tableWidget->rowCount();
    int columnLength = ui->tableWidget->columnCount();

    if (ui->tableWidget->currentRow() < 0 || ui->tableWidget->currentColumn() < 0){
        ui->tableWidget->item(itmePosition.front().first, itmePosition.front().second)->setSelected(true);
        ui->tableWidget->setCurrentCell(itmePosition.front().first, itmePosition.front().second);
        return;
    }

    int row = ui->tableWidget->currentRow();
    int column = ui->tableWidget->currentColumn();
    int tempRow, tempCol;

    int count = (rowLength*columnLength);

    ui->tableWidget->item(row, column)->setSelected(false);
    // check if current item has been modified
    if (ui->tableWidget->item(row, column)->text() != NULL){
        QBrush unBrush(QColor(255, 255, 255, 100));
        ui->tableWidget->item(row, column)->setBackground(unBrush);
        std::pair<int,int> p;
        p.first = row;
        p.second = column;
        itmePosition.remove(p);

        if (errorCount != 0){
            errorCount -= 1;
        }
        ui->errorLabel->setText(QString::number(errorCount));
    }

    for (int i = 1; i<=count; i++){

        if (i == 1){
            tempCol = column + 1;
            tempRow = row;
        }
        else {
            tempCol += 1;
        }
        if (tempCol > columnLength-1){
            tempCol -= columnLength;
            tempRow += 1;
        }
        if (tempRow > rowLength-1){
            tempRow -= rowLength;
        }

        for (std::list<std::pair<int,int>>::iterator it=itmePosition.begin(); it != itmePosition.end(); ++it){
            if (tempRow == (*it).first && tempCol == (*it).second){
                ui->tableWidget->item(tempRow, tempCol)->setSelected(true);
                ui->tableWidget->setCurrentCell(tempRow, tempCol);
                return;
            }
        }

    }

}
