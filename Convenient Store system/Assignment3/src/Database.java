import java.io.*;
import java.text.SimpleDateFormat;
import java.util.*;

public class Database {
	
	private LinkedList<String[]> goodsList = new LinkedList<String[]>();
	
	private Map<Integer, Integer> goodsInStore = new HashMap<Integer, Integer>();
	
	private Map<String, ArrayList<String[]>> goodsSold = new HashMap<String, ArrayList<String[]>>();
	
	public Database(){
		
		updateGoodsList();
		updateGoodsInStore();
		updateGoodsSold();
		
	}
	
	// get goodsList
	public LinkedList<String[]> getGoodsList(){
		return goodsList;
	}
	
	// update goodsList
	private void updateGoodsList(){
		try {
			File f = new File("goods_list");
			InputStreamReader reader = new InputStreamReader(new FileInputStream(f));
			BufferedReader br = new BufferedReader(reader);

			String line = br.readLine();
			while (line != null){
				String[] goodsDetail = line.split(",");
				
				goodsList.add(goodsDetail);
				line = br.readLine();
				
			}
			br.close();
			
		} catch (Exception e) {
			e.printStackTrace(); 
		}
	}
	
	// rewrite goodsList to file
	private void rewriteGoodsList(){
		try {  
            File f = new File("goods_list");  
            PrintStream ps = new PrintStream(new FileOutputStream(f));  
            
            //ps.println("");
            
            for (String[] strs : goodsList){
            	for (int i=0; i<strs.length; i++){
            		ps.append(strs[i]);
            		ps.append(",");
            	}
            	ps.append("\n");
            }
            
            ps.close();
            
        } catch (FileNotFoundException e) {  
            // TODO Auto-generated catch block  
            e.printStackTrace();  
        }  
	}
	
	// delete item
	public boolean deleteGoods(String id){
		for (int i=0; i < goodsList.size(); i++){
        	if (goodsList.get(i)[0].equals(id)){
        		goodsList.remove(i);
        		this.rewriteGoodsList();
        		return true;
        	}
        }
		return false;
	}
	
	// add item
	public boolean addGoods(String id, String name, String price, String category){
		// no duplicate ID
		for (int i=0; i < goodsList.size(); i++){
        	if (goodsList.get(i)[0].equals(id)){
        		return false;
        	}
        }
		String[] newGoods = new String[4];
		newGoods[0] = id;
		newGoods[1] = name;
		newGoods[2] = price;
		newGoods[3] = category;
		goodsList.add(newGoods);
		this.rewriteGoodsList();
		
		if (!goodsInStore.containsKey(Integer.parseInt(id))){
			// add to goodsInStore
			goodsInStore.put(Integer.parseInt(id), 0);
		}
		
		return true;
	}
	
	// return all categories in goodsList
	public ArrayList<String> getCategories() {
		ArrayList<String> cates = new ArrayList<String>();
		for (String[] strs : goodsList) {
			if (!cates.contains(strs[3])) {
				cates.add(strs[3]);
			}
			
		}
		return cates;
	}
	
	// get name by id
	private String searchName(String id) {
		for (String[] strs : goodsList) {
			if (id.equals(strs[0])) {
				return strs[1];
			}
		}
		return "";
	}
	
	// get price by id
	private float searchPrice(String id) {
		for (String[] strs : goodsList) {
			if (id.equals(strs[0])) {
				return Float.parseFloat(strs[2]);
			}
		}
		return 0;
	}
	
	/////// Goods in store ///////

	// get goodsInStore
	public Map<Integer, Integer> getGoodsInStore() {
		return goodsInStore;
	}

	// update goodsInStore
	private void updateGoodsInStore() {
		try {
			File f = new File("goods_in_store");
			InputStreamReader reader = new InputStreamReader(new FileInputStream(f));
			BufferedReader br = new BufferedReader(reader);

			String line = br.readLine();
			while (line != null) {
				String[] goodsDetail = line.split(",");
				goodsInStore.put(Integer.parseInt(goodsDetail[0]), Integer.parseInt(goodsDetail[1]));

				line = br.readLine();

			}
			br.close();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	// rewrite goodsInStore to file
	private void rewriteGoodsInStore(){
		try {  
            File f = new File("goods_in_store");  
            PrintStream ps = new PrintStream(new FileOutputStream(f));  
            
            for (int key : goodsInStore.keySet()){
            	ps.append(String.format("%04d", key) + ",");
            	ps.append(goodsInStore.get(key) + "\n");
            }
            
            ps.close();
            
        } catch (FileNotFoundException e) {  
            // TODO Auto-generated catch block  
            e.printStackTrace();  
        }  
	}
	
	// purchase to fill goodsInStore
	public boolean fillGoods(String id, int amount){
		int idNumber = Integer.parseInt(id);
		if (goodsInStore.containsKey(idNumber)){
			goodsInStore.put(idNumber, goodsInStore.get(idNumber) + amount);
			this.rewriteGoodsInStore();
			return true;
		}
		return false;
	}
	
	// sell goods
	public boolean sellGoods(String id, int amount){
		int idNumber = Integer.parseInt(id);
		if (goodsInStore.containsKey(idNumber)) {
			int finalAmount = goodsInStore.get(idNumber) - amount;
			if (finalAmount >= 0) {
				goodsInStore.put(idNumber, finalAmount);
				this.rewriteGoodsInStore();
				return true;
			}
		}
		return false;
	}
	
	// search numbers in store by ID
	private int searchAmount(String ID) {
		return goodsInStore.get(Integer.parseInt(ID));
	}
	
	
	/////////// sold goods ////////////
	// update goodsSold
	private void updateGoodsSold() {
		try {
			File f = new File("sells_list");
			InputStreamReader reader = new InputStreamReader(new FileInputStream(f));
			BufferedReader br = new BufferedReader(reader);

			String line = br.readLine();
			String date = "1/1/2018";
			while (line != null) {
				if (line.equals("Time")) {
					date = br.readLine();
					line = br.readLine();
					ArrayList<String[]> sells = new ArrayList<String[]>();
					goodsSold.put(date, sells);
				}
				String[] goodsDetail = line.split(",");
				goodsSold.get(date).add(goodsDetail);
				
				line = br.readLine();

			}
			br.close();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	// rewrite goodsSold to file
	private void rewriteGoodsSold(){
		try {  
            File f = new File("sells_list");  
            PrintStream ps = new PrintStream(new FileOutputStream(f));  
            
            
            for (Map.Entry<String, ArrayList<String[]>> entry : goodsSold.entrySet()){
            	ps.append("Time\n");
            	ps.append(entry.getKey()+"\n");
            	for (String[] strs : entry.getValue()){
            		ps.append(strs[0] + "," + strs[1]);
                	ps.append("\n");
            	}
            }
            
            ps.close();
            
        } catch (FileNotFoundException e) {  
            // TODO Auto-generated catch block  
            e.printStackTrace();  
        }  
	}
	
	// sell group items
	public void sellGroup(ArrayList<String[]> group) {
		String todayAsString = new SimpleDateFormat("dd/MM/yyyy").format(new Date());
		if (goodsSold.containsKey(todayAsString)) {
			for (int i=0; i<group.size(); i++) {
				boolean add = true;
				for (String[] strs : goodsSold.get(todayAsString)) {
					if (strs[0].equals(group.get(i)[0])) {
						strs[1] = Integer.parseInt(strs[1]) + Integer.parseInt(group.get(i)[1]) + "";
						add = false;
					}
				}
				if (add) {
					goodsSold.get(todayAsString).add(group.get(i));
				}
				sellGoods(group.get(i)[0], Integer.parseInt(group.get(i)[1]));
			}
		}
		else {
			goodsSold.put(todayAsString, group);
			for (String[] strs : group) {
				sellGoods(strs[0], Integer.parseInt(strs[1]));
			}
		}
		this.rewriteGoodsInStore();
		this.rewriteGoodsSold();
	}
	
	// get all dates
	public String[] getAllDates() {
		String[] dates = new String[goodsSold.size()];
		int i=0;
		for (String str : goodsSold.keySet()) {
			dates[i] = str;
			i++;
		}
		return dates;
	}
	
	// get sell records for passing date
	public String[] getReport(String date) {
		float totalPrice = 0;
		ArrayList<String[]> records = goodsSold.get(date);
		String[] results = new String[records.size()+1];
		for (int i=0; i<records.size(); i++) {
			results[i] = records.get(i)[0] + "\t\t\t\t\t\t\t\tSell:" + records.get(i)[1];
			totalPrice += searchPrice(records.get(i)[0]) * Integer.parseInt(records.get(i)[1]);
		}
		results[records.size()] = "Money of Sales: " + totalPrice;

		return results;
	}
	
	
	/////////// operations ////////////
	// search goods in store
	public ArrayList<String[]> customerSearch(String name, float min, float max, String cate){
		ArrayList<String[]> results = new ArrayList<String[]>();
		for (String[] strs : goodsList) {
			if (name.isEmpty() || strs[1].toLowerCase().equals(name.toLowerCase())) {
				float price = Float.parseFloat(strs[2]);
				if ((min==0 && max==0) || (min <= price && max >= price)) {
					if (cate.equals("All") || cate.equals(strs[3])) {
						String[] r = new String[2];
						r[0] = strs[1];
						if (searchAmount(strs[0]) > 0) {
							r[1] = "In store";
						}
						else {
							r[1] = "Sold out";
						}
						results.add(r);
					}
				}
			}
		}
		
		return results;
	}
	
	// search goods  below the amount
	public String[] purchaseGoods(int amount) {
		ArrayList<String> results = new ArrayList<String>();
		results.add("ID" + "\t\t\t\t\t" + "NAME" + "\t\t\t\t\t" + "AMOUNT");
		for (Map.Entry<Integer, Integer> entry : goodsInStore.entrySet()){
		    if (entry.getValue() <= amount) {
		    	String str = String.format("%04d", entry.getKey()) + "\t\t\t\t\t" + searchName(String.format("%04d", entry.getKey())) 
		    	+ "\t\t\t\t\t" + entry.getValue();
		    	
		    	results.add(str);
		    }
		}
		
		return results.toArray(new String[results.size()]);
	}
	
	
	
	/*
	public static void main(String[] args) {
		// TODO Auto-generated method stub

		Database d1 = new Database();
		d1.updateGoodsSold();
		d1.rewriteGoodsSold();
		
	}
	*/

}
