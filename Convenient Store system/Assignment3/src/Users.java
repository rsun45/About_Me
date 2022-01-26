
public class Users {
	
	private String cashierAccount;
	private String cashierPassword;
	
	private String managerAccount;
	private String managerPassword;
	
	public Users(){
		cashierAccount = "cashier";
		cashierPassword = "cashier";
		managerAccount = "manager";
		managerPassword = "manager";
	}
	
	
	// check login status
	// 0-wrong; 1-cashier; 2-manager
	public int login(String account, String password) {
		if (account.equals(cashierAccount) && password.contentEquals(cashierPassword)) {
			return 1;
		}
		else if (account.equals(managerAccount) && password.contentEquals(managerPassword)) {
			return 2;
		}
		else {
			return 0;
		}
	}
	
	/*
	// get cashier password
	public String getCashierPassword(){
		return cashierPassword;
	}
	
	// get manager password
	public String getManagerPassword(){
		return managerPassword;
	}
	
	// get manager account
	public String getCashierAccount(){
		return cashierAccount;
	}
	
	// get manager password
	public String getManagerAccount(){
		return managerAccount;
	}
	
	*/


}
