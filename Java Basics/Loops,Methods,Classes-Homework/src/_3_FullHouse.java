
public class _3_FullHouse {

	public static void main(String[] args) {
		String[] face = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
		String[] suit = {"♠", "♣", "♦", "♥"};
		int counter = 0;
		for (int i = 0; i < face.length; i++) {
			for (int j = 0; j < face.length; j++) {
				for (int k = 0; k < suit.length; k++) {
					for (int m = k + 1; m < suit.length; m++) {
						for (int l = m + 1; l < suit.length; l++) {
							for (int n = 0; n < suit.length; n++) {
								for (int o = n + 1; o < suit.length; o++) {
									if (i != j) {
										System.out.printf("(%s%s %s%s %s%s %s%s %s%s) ", face[i], suit[k], face[i]
												, suit[m], face[i], suit[l], face[j], suit[n], face[j], suit[o]);
										counter++;
									}
								}
							}
						}
					}
				}
			}
		}
	}

}
