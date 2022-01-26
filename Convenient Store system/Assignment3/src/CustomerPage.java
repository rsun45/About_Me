import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.DefaultComboBoxModel;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.JTextPane;
import javax.swing.LayoutStyle.ComponentPlacement;
import javax.swing.ListModel;
import javax.swing.JTextField;
import javax.swing.JComboBox;
import javax.swing.JButton;
import java.awt.Font;
import java.awt.Color;
import javax.swing.JLabel;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import javax.swing.JToggleButton;
import javax.swing.JList;


public class CustomerPage extends JFrame {

	private JPanel contentPane;
	private JTextField txtSearchByName;
	private JTextField txtMinPrice;
	private JTextField textMaxPrice;

	/**
	 * Launch the application.
	 */
	/*
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					CustomerPage frame = new CustomerPage();
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
	public CustomerPage() {
		
		// initial database
		Database db = new Database();
		
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 600, 400);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		
		txtSearchByName = new JTextField();
		txtSearchByName.setColumns(10);
		
		txtMinPrice = new JTextField();
		txtMinPrice.setColumns(10);
		
		JList<String> customerSearchList = new JList<String>();
		GroupLayout gl_contentPane = new GroupLayout(contentPane);
		
		JComboBox<String> categoryComboBox = new JComboBox<String>();
		categoryComboBox.setToolTipText("");
		
		// add items for category combo box
		categoryComboBox.addItem("All");
		for (String str : db.getCategories()) {
			categoryComboBox.addItem(str);
		}
		
		
		JButton customerSearchButton = new JButton("Search");
		customerSearchButton.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				
				// name
				String name = txtSearchByName.getText();
				// price min to max
				float min, max;
				if (txtMinPrice.getText().isEmpty()) {
					min = 0f;
				}
				else {
					min = Float.parseFloat(txtMinPrice.getText());
				}
				if (textMaxPrice.getText().isEmpty()) {
					max = 0f;
				}
				else {
					max = Float.parseFloat(textMaxPrice.getText());
				}
				
				// category
				String cate = String.valueOf(categoryComboBox.getSelectedItem());
				
				// search all items
				ArrayList<String[]> results = db.customerSearch(name, min, max, cate);
				// convert to string array
				String[] items;
				if (results.isEmpty()) {
					items = new String[2];
					items[0] = "Sorry, No Search Result.";
					items[1] = "May search a wider range.";
				}
				else {
					items = new String[results.size()];
				}
				for (int i=0; i<results.size(); i++) {
					items[i] = results.get(i)[0] + "\t\t\t\t\t\t\t\t" + results.get(i)[1];
				}
				ListModel<String> jListModel =  new DefaultComboBoxModel<String>(items); 
				customerSearchList.setModel(jListModel);
				
			}
		});
		customerSearchButton.setForeground(new Color(255, 204, 0));
		customerSearchButton.setFont(new Font("Lucida Grande", Font.PLAIN, 18));
		
		JLabel lblNewLabel = new JLabel("Search by name:");
		
		JLabel lblNewLabel_1 = new JLabel("Search by price:");
		
		JLabel lblNewLabel_2 = new JLabel("Search by categry:");
		
		JButton backButton = new JButton("Back");
		backButton.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {

				dispose();
				WelcomPage wp = new WelcomPage();
				wp.setVisible(true);
				
				
			}
		});
		backButton.setForeground(Color.BLACK);
		backButton.setFont(new Font("Lucida Grande", Font.PLAIN, 18));
		
		JLabel lblNewLabel_3 = new JLabel("to");
		
		textMaxPrice = new JTextField();
		textMaxPrice.setColumns(10);
		
		
		
		
		gl_contentPane.setHorizontalGroup(
			gl_contentPane.createParallelGroup(Alignment.TRAILING)
				.addGroup(gl_contentPane.createSequentialGroup()
					.addGap(15)
					.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING)
						.addComponent(txtSearchByName, GroupLayout.DEFAULT_SIZE, 206, Short.MAX_VALUE)
						.addComponent(lblNewLabel, GroupLayout.PREFERRED_SIZE, 115, GroupLayout.PREFERRED_SIZE)
						.addGroup(gl_contentPane.createParallelGroup(Alignment.TRAILING, false)
							.addComponent(lblNewLabel_2, Alignment.LEADING, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
							.addComponent(categoryComboBox, Alignment.LEADING, 0, 142, Short.MAX_VALUE)
							.addComponent(customerSearchButton, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
						.addComponent(backButton)
						.addGroup(gl_contentPane.createSequentialGroup()
							.addComponent(txtMinPrice, GroupLayout.PREFERRED_SIZE, 68, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED)
							.addComponent(lblNewLabel_3, GroupLayout.PREFERRED_SIZE, 23, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED)
							.addComponent(textMaxPrice, GroupLayout.PREFERRED_SIZE, 68, GroupLayout.PREFERRED_SIZE))
						.addComponent(lblNewLabel_1, GroupLayout.PREFERRED_SIZE, 108, GroupLayout.PREFERRED_SIZE))
					.addGap(47)
					.addComponent(customerSearchList, GroupLayout.PREFERRED_SIZE, 322, GroupLayout.PREFERRED_SIZE))
		);
		gl_contentPane.setVerticalGroup(
			gl_contentPane.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_contentPane.createSequentialGroup()
					.addGap(14)
					.addComponent(lblNewLabel)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(txtSearchByName, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.UNRELATED)
					.addComponent(lblNewLabel_1)
					.addGap(4)
					.addGroup(gl_contentPane.createParallelGroup(Alignment.BASELINE)
						.addComponent(txtMinPrice, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
						.addComponent(lblNewLabel_3)
						.addComponent(textMaxPrice, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
					.addPreferredGap(ComponentPlacement.UNRELATED)
					.addComponent(lblNewLabel_2)
					.addGap(10)
					.addComponent(categoryComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
					.addGap(53)
					.addComponent(customerSearchButton, GroupLayout.PREFERRED_SIZE, 42, GroupLayout.PREFERRED_SIZE)
					.addGap(35)
					.addComponent(backButton, GroupLayout.PREFERRED_SIZE, 39, GroupLayout.PREFERRED_SIZE)
					.addContainerGap(17, Short.MAX_VALUE))
				.addGroup(Alignment.TRAILING, gl_contentPane.createSequentialGroup()
					.addContainerGap(GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
					.addComponent(customerSearchList, GroupLayout.PREFERRED_SIZE, 365, GroupLayout.PREFERRED_SIZE)
					.addContainerGap())
		);
		contentPane.setLayout(gl_contentPane);
	}
}
