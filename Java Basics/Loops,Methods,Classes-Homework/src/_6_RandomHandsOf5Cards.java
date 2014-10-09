import java.util.Random;
import java.util.Scanner;


public class _6_RandomHandsOf5Cards {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		String[] face = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
		String[] suit = {"♠", "♣", "♦", "♥"};
		Random rnd = new Random();
		int rndNum = 0;
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < 5; j++) {
				rndNum = rnd.nextInt((12 - 0) + 1) + 0;
				System.out.print(face[rndNum]);
				rndNum = rnd.nextInt((3 - 0) + 1) + 0;
				System.out.print(suit[rndNum]);
			}
			System.out.println();
		}
	}

}
