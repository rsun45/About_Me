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
import javax.swing.JTextPane;
import javax.swing.ListModel;
import javax.swing.JTextField;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import javax.swing.JList;

public class ManagerPage extends JFrame {

	private JPanel contentPane;
	private JTextField textField;

	/**
	 * Launch the application.
	 */
	/*
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ManagerPage frame = new ManagerPage();
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
	public ManagerPage() {
		
		// initial database
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
				.addComponent(tabbedPane, GroupLayout.DEFAULT_SIZE, 590, Short.MAX_VALUE)
		);
		gl_contentPane.setVerticalGroup(
			gl_contentPane.createParallelGroup(Alignment.LEADING)
				.addComponent(tabbedPane, GroupLayout.DEFAULT_SIZE, 368, Short.MAX_VALUE)
		);
		
		JPanel welcomTab = new JPanel();
		tabbedPane.addTab("Welcome", null, welcomTab, null);
		
		JLabel lblNewLabel = new JLabel("Welcome Manager");
		lblNewLabel.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel.setFont(new Font("Lucida Grande", Font.PLAIN, 18));
		
		JButton btnNewButton = new JButton("Exit");
		btnNewButton.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				
				dispose();
				WelcomPage wp = new WelcomPage();
				wp.setVisible(true);
				
			}
		});
		btnNewButton.setFont(new Font("Lucida Grande", Font.PLAIN, 16));
		GroupLayout gl_welcomTab = new GroupLayout(welcomTab);
		gl_welcomTab.setHorizontalGroup(
			gl_welcomTab.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_welcomTab.createSequentialGroup()
					.addGroup(gl_welcomTab.createParallelGroup(Alignment.LEADING)
						.addGroup(gl_welcomTab.createSequentialGroup()
							.addGap(193)
							.addComponent(lblNewLabel, GroupLayout.PREFERRED_SIZE, 182, GroupLayout.PREFERRED_SIZE))
						.addGroup(gl_welcomTab.createSequentialGroup()
							.addGap(216)
							.addComponent(btnNewButton, GroupLayout.PREFERRED_SIZE, 130, GroupLayout.PREFERRED_SIZE)))
					.addContainerGap(194, Short.MAX_VALUE))
		);
		gl_welcomTab.setVerticalGroup(
			gl_welcomTab.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_welcomTab.createSequentialGroup()
					.addGap(54)
					.addComponent(lblNewLabel, GroupLayout.PREFERRED_SIZE, 40, GroupLayout.PREFERRED_SIZE)
					.addGap(151)
					.addComponent(btnNewButton, GroupLayout.PREFERRED_SIZE, 39, GroupLayout.PREFERRED_SIZE)
					.addContainerGap(38, Short.MAX_VALUE))
		);
		welcomTab.setLayout(gl_welcomTab);
		
		JPanel purchaseTab = new JPanel();
		tabbedPane.addTab("Purchase", null, purchaseTab, null);
		

		JList<String> list = new JList<String>();
		GroupLayout gl_purchaseTab = new GroupLayout(purchaseTab);
		
		JButton btnSearch = new JButton("Search");
		btnSearch.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				int amount;
				if (textField.getText().isEmpty()) {
					amount = 0;
				}else {
					amount = Integer.parseInt(textField.getText());
				}
				ListModel<String> jListModel =  new DefaultComboBoxModel<String>(db.purchaseGoods(amount)); 
				list.setModel(jListModel);
				
			}
		});
		
		textField = new JTextField();
		textField.setColumns(10);
		
		JLabel lblSearchGoodsIn = new JLabel("<html>Search goods in store<br/>under the amount:</html>");
		
		
		
		
		gl_purchaseTab.setHorizontalGroup(
			gl_purchaseTab.createParallelGroup(Alignment.TRAILING)
				.addGroup(gl_purchaseTab.createSequentialGroup()
					.addGroup(gl_purchaseTab.createParallelGroup(Alignment.TRAILING)
						.addGroup(gl_purchaseTab.createSequentialGroup()
							.addGap(49)
							.addGroup(gl_purchaseTab.createParallelGroup(Alignment.LEADING)
								.addComponent(btnSearch, GroupLayout.PREFERRED_SIZE, 116, GroupLayout.PREFERRED_SIZE)
								.addComponent(textField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
							.addPreferredGap(ComponentPlacement.RELATED, 50, Short.MAX_VALUE))
						.addGroup(gl_purchaseTab.createSequentialGroup()
							.addContainerGap()
							.addComponent(lblSearchGoodsIn, GroupLayout.PREFERRED_SIZE, 178, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED)))
					.addGap(18)
					.addComponent(list, GroupLayout.PREFERRED_SIZE, 322, GroupLayout.PREFERRED_SIZE)
					.addContainerGap())
		);
		gl_purchaseTab.setVerticalGroup(
			gl_purchaseTab.createParallelGroup(Alignment.TRAILING)
				.addGroup(gl_purchaseTab.createSequentialGroup()
					.addGap(70)
					.addComponent(lblSearchGoodsIn, GroupLayout.PREFERRED_SIZE, 51, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(textField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED, 134, Short.MAX_VALUE)
					.addComponent(btnSearch)
					.addContainerGap())
				.addGroup(gl_purchaseTab.createSequentialGroup()
					.addContainerGap(GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
					.addComponent(list, GroupLayout.PREFERRED_SIZE, 316, GroupLayout.PREFERRED_SIZE))
		);
		purchaseTab.setLayout(gl_purchaseTab);
		contentPane.setLayout(gl_contentPane);
	}
}
