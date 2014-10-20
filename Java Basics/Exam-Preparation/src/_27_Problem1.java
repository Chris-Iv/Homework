import java.util.Scanner;


public class _27_Problem1 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int beers = 0;
		int stacks = 0;
		while (true) {
			String entryLine = input.nextLine();
			if (entryLine.equals("End")) {
				break;
			}
			String[] entry = entryLine.split(" ");
			if (entry[1].equals("beers")) {
				beers += Integer.parseInt(entry[0]);
			} else if (entry[1].equals("stacks")) {
				stacks += Integer.parseInt(entry[0]);
			}
		}
		stacks += beers / 20;
		beers = beers % 20;
		System.out.printf("%d stacks + %d beers", stacks, beers);
	}

}
