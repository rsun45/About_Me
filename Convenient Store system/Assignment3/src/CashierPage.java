import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.DefaultComboBoxModel;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.JTabbedPane;
import javax.swing.JLabel;
import java.awt.Font;
import javax.swing.SwingConstants;
import javax.swing.JButton;
import javax.swing.LayoutStyle.ComponentPlacement;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;

import javax.swing.JTextField;
import javax.swing.JTextPane;
import javax.swing.ListModel;
import javax.swing.JList;
import javax.swing.JOptionPane;
import javax.swing.JComboBox;
import java.awt.event.FocusAdapter;
import java.awt.event.FocusEvent;

public class CashierPage extends JFrame {

	private JPanel contentPane;
	private JTextField IDtextField;
	private JTextField amountTextField;
	private ArrayList<String[]> tempSells;

	/**
	 * Launch the application.
	 */
	/*
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					CashierPage frame = new CashierPage();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}
	*/

	/**
	 * Create the frame.
	 */
	public CashierPage() {
		
		// initial things
		tempSells = new ArrayList<String[]>();
		Database db = new Database();
		
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 600, 400);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		
		JTabbedPane tabbedPane = new JTabbedPane(JTabbedPane.TOP);
		GroupLayout gl_contentPane = new GroupLayout(contentPane);
		gl_contentPane.setHorizontalGroup(
			gl_contentPane.createParallelGroup(Alignment.LEADING)
				.addComponent(tabbedPane, GroupLayout.DEFAULT_SIZE, 440, Short.MAX_VALUE)
		);
		gl_contentPane.setVerticalGroup(
			gl_contentPane.createParallelGroup(Alignment.LEADING)
				.addComponent(tabbedPane, GroupLayout.DEFAULT_SIZE, 268, Short.MAX_VALUE)
		);
		
		JPanel welcomTab = new JPanel();
		tabbedPane.addTab("Welcome", null, welcomTab, null);
		
		JLabel lblWelcomeCashier = new JLabel("Welcome Cashier");
		lblWelcomeCashier.setHorizontalAlignment(SwingConstants.CENTER);
		lblWelcomeCashier.setFont(new Font("Lucida Grande", Font.PLAIN, 18));
		
		JButton button = new JButton("Exit");
		button.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				
				dispose();
				WelcomPage wp = new WelcomPage();
				wp.setVisible(true);
				
			}
		});
		button.setFont(new Font("Lucida Grande", Font.PLAIN, 16));
		GroupLayout gl_welcomTab = new GroupLayout(welcomTab);
		gl_welcomTab.setHorizontalGroup(
			gl_welcomTab.createParallelGroup(Alignment.LEADING)
				.addGroup(Alignment.TRAILING, gl_welcomTab.createSequentialGroup()
					.addContainerGap(194, Short.MAX_VALUE)
					.addComponent(lblWelcomeCashier, GroupLayout.PREFERRED_SIZE, 182, GroupLayout.PREFERRED_SIZE)
					.addGap(193))
				.addGroup(gl_welcomTab.createSequentialGroup()
					.addGap(217)
					.addComponent(button, GroupLayout.PREFERRED_SIZE, 130, GroupLayout.PREFERRED_SIZE)
					.addContainerGap(222, Short.MAX_VALUE))
		);
		gl_welcomTab.setVerticalGroup(
			gl_welcomTab.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_welcomTab.createSequentialGroup()
					.addGap(61)
					.addComponent(lblWelcomeCashier, GroupLayout.PREFERRED_SIZE, 40, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED, 124, Short.MAX_VALUE)
					.addComponent(button, GroupLayout.PREFERRED_SIZE, 39, GroupLayout.PREFERRED_SIZE)
					.addGap(58))
		);
		welcomTab.setLayout(gl_welcomTab);
		
		JPanel sellTab = new JPanel();
		tabbedPane.addTab("Sell", null, sellTab, null);
		
		JLabel lblNewLabel = new JLabel("Product ID:");
		lblNewLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		
		JLabel lblAmount = new JLabel("Amount:");
		lblAmount.setHorizontalAlignment(SwingConstants.RIGHT);
		
		IDtextField = new JTextField();
		IDtextField.setColumns(10);
		
		amountTextField = new JTextField();
		amountTextField.setColumns(10);
		
		JList<String> list = new JList<String>();
		GroupLayout gl_sellTab = new GroupLayout(sellTab);
		
		
		JButton btnNewButton = new JButton("Sell");
		btnNewButton.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				
				String[] strs = new String[2];
				strs[0] = IDtextField.getText();
				strs[1] = amountTextField.getText();
				if (!strs[0].isEmpty() && !strs[1].isEmpty()) {
					tempSells.add(strs);
				}
				
				// update jList
				String[] items = new String[tempSells.size()];
				for (int i=0; i<tempSells.size(); i++) {
					items[i] = tempSells.get(i)[0] + "\t\t\t\t\t\t\t\tSell:" + tempSells.get(i)[1];
				}
				ListModel<String> jListModel =  new DefaultComboBoxModel<String>(items); 
				list.setModel(jListModel);
				
			}
		});
		btnNewButton.setFont(new Font("Lucida Grande", Font.PLAIN, 18));
		
		
		JComboBox<String> dateComboBox = new JComboBox<String>();
		
		JButton btnNewButton_1 = new JButton("Finish");
		btnNewButton_1.addMouseListener(new MouseAdapter() {
			@Override
			////////// check out for group goods /////////
			public void mouseClicked(MouseEvent e) {
				
				db.sellGroup(tempSells);
				tempSells = new ArrayList<String[]>();
				ListModel<String> jListModel =  new DefaultComboBoxModel<String>(); 
				list.setModel(jListModel);
				JOptionPane.showMessageDialog(null, "Success for Chacking Out.");
				
				// update items for category combo box
				dateComboBox.removeAllItems();
				for (String str : db.getAllDates()) {
					dateComboBox.addItem(str);
				}
				
			}
		});
		
		gl_sellTab.setHorizontalGroup(
			gl_sellTab.createParallelGroup(Alignment.LEADING)
				.addGroup(Alignment.TRAILING, gl_sellTab.createSequentialGroup()
					.addGroup(gl_sellTab.createParallelGroup(Alignment.LEADING)
						.addGroup(gl_sellTab.createSequentialGroup()
							.addContainerGap(23, Short.MAX_VALUE)
							.addGroup(gl_sellTab.createParallelGroup(Alignment.LEADING)
								.addComponent(lblNewLabel, GroupLayout.PREFERRED_SIZE, 134, GroupLayout.PREFERRED_SIZE)
								.addComponent(lblAmount, GroupLayout.PREFERRED_SIZE, 134, GroupLayout.PREFERRED_SIZE))
							.addPreferredGap(ComponentPlacement.RELATED))
						.addGroup(gl_sellTab.createSequentialGroup()
							.addComponent(btnNewButton_1, GroupLayout.PREFERRED_SIZE, 116, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED)))
					.addPreferredGap(ComponentPlacement.RELATED)
					.addGroup(gl_sellTab.createParallelGroup(Alignment.TRAILING)
						.addGroup(gl_sellTab.createParallelGroup(Alignment.LEADING)
							.addComponent(IDtextField, GroupLayout.PREFERRED_SIZE, 180, GroupLayout.PREFERRED_SIZE)
							.addComponent(amountTextField, GroupLayout.PREFERRED_SIZE, 180, GroupLayout.PREFERRED_SIZE))
						.addComponent(btnNewButton, GroupLayout.PREFERRED_SIZE, 137, GroupLayout.PREFERRED_SIZE))
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(list, GroupLayout.PREFERRED_SIZE, 217, GroupLayout.PREFERRED_SIZE)
					.addGap(3))
		);
		gl_sellTab.setVerticalGroup(
			gl_sellTab.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_sellTab.createSequentialGroup()
					.addGap(81)
					.addGroup(gl_sellTab.createParallelGroup(Alignment.LEADING)
						.addGroup(Alignment.TRAILING, gl_sellTab.createSequentialGroup()
							.addComponent(IDtextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.UNRELATED)
							.addComponent(amountTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED, 108, Short.MAX_VALUE)
							.addGroup(gl_sellTab.createParallelGroup(Alignment.LEADING)
								.addGroup(Alignment.TRAILING, gl_sellTab.createSequentialGroup()
									.addComponent(btnNewButton_1)
									.addContainerGap())
								.addGroup(Alignment.TRAILING, gl_sellTab.createSequentialGroup()
									.addComponent(btnNewButton, GroupLayout.PREFERRED_SIZE, 43, GroupLayout.PREFERRED_SIZE)
									.addGap(26))))
						.addGroup(gl_sellTab.createSequentialGroup()
							.addComponent(lblNewLabel, GroupLayout.PREFERRED_SIZE, 26, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.UNRELATED)
							.addComponent(lblAmount, GroupLayout.PREFERRED_SIZE, 26, GroupLayout.PREFERRED_SIZE))))
				.addGroup(Alignment.TRAILING, gl_sellTab.createSequentialGroup()
					.addContainerGap(7, Short.MAX_VALUE)
					.addComponent(list, GroupLayout.PREFERRED_SIZE, 315, GroupLayout.PREFERRED_SIZE))
		);
		sellTab.setLayout(gl_sellTab);

		
		JPanel reportTab = new JPanel();	
		tabbedPane.addTab("Report", null, reportTab, null);
		
		
		// add items for category combo box
		for (String str : db.getAllDates()) {
			dateComboBox.addItem(str);
		}
		
		JLabel lblNewLabel_1 = new JLabel("Select Date:");
		

		JList<String> list_report = new JList<String>();
		GroupLayout gl_reportTab = new GroupLayout(reportTab);
		
		JButton Button_searchDate = new JButton("Search");
		Button_searchDate.addMouseListener(new MouseAdapter() {
			@Override
			// button to show sell status for date
			public void mouseClicked(MouseEvent e) {

				ListModel<String> jListModel =  new DefaultComboBoxModel<String>(db.getReport(String.valueOf(dateComboBox.getSelectedItem()))); 
				list_report.setModel(jListModel);
				
			}
		});
		

		
		gl_reportTab.setHorizontalGroup(
			gl_reportTab.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_reportTab.createSequentialGroup()
					.addGroup(gl_reportTab.createParallelGroup(Alignment.LEADING)
						.addGroup(gl_reportTab.createSequentialGroup()
							.addGap(45)
							.addGroup(gl_reportTab.createParallelGroup(Alignment.LEADING)
								.addGroup(gl_reportTab.createSequentialGroup()
									.addComponent(dateComboBox, GroupLayout.PREFERRED_SIZE, 175, GroupLayout.PREFERRED_SIZE)
									.addGap(50))
								.addGroup(gl_reportTab.createSequentialGroup()
									.addComponent(lblNewLabel_1, GroupLayout.DEFAULT_SIZE, 225, Short.MAX_VALUE)
									.addPreferredGap(ComponentPlacement.RELATED))))
						.addGroup(gl_reportTab.createSequentialGroup()
							.addGap(70)
							.addComponent(Button_searchDate, GroupLayout.PREFERRED_SIZE, 130, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED)))
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(list_report, GroupLayout.PREFERRED_SIZE, 287, GroupLayout.PREFERRED_SIZE)
					.addContainerGap())
		);
		gl_reportTab.setVerticalGroup(
			gl_reportTab.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_reportTab.createSequentialGroup()
					.addGap(67)
					.addComponent(lblNewLabel_1, GroupLayout.PREFERRED_SIZE, 24, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.UNRELATED)
					.addComponent(dateComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED, 93, Short.MAX_VALUE)
					.addComponent(Button_searchDate, GroupLayout.PREFERRED_SIZE, 40, GroupLayout.PREFERRED_SIZE)
					.addGap(59))
				.addGroup(gl_reportTab.createSequentialGroup()
					.addContainerGap()
					.addComponent(list_report, GroupLayout.DEFAULT_SIZE, 310, Short.MAX_VALUE)
					.addContainerGap())
		);
		reportTab.setLayout(gl_reportTab);
		contentPane.setLayout(gl_contentPane);
	}
}
