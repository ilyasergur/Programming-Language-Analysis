import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.LinkedHashSet;
import java.util.Set;

public class File_IO {
    public static void main(String[] args) {
        String inputFile = "BIL240_proje_verisi_95mb.txt";
        String outputFile = "temiz_veri_java.txt";

        long startTime = System.currentTimeMillis();
        Runtime runtime = Runtime.getRuntime();
        runtime.gc();

        Set<String> uniqueLines = new LinkedHashSet<>();

        try (BufferedReader reader = new BufferedReader(
                new InputStreamReader(new FileInputStream(inputFile), StandardCharsets.UTF_8))) {
            
            String line;
            while ((line = reader.readLine()) != null) {
                uniqueLines.add(line);
            }

            try (BufferedWriter writer = new BufferedWriter(
                    new OutputStreamWriter(new FileOutputStream(outputFile), StandardCharsets.UTF_8))) {
                for (String uniqueLine : uniqueLines) {
                    writer.write(uniqueLine);
                    writer.newLine();
                }
            }

        } catch (IOException e) {
            e.printStackTrace();
        }

        long endTime = System.currentTimeMillis();
        long usedMemory = (runtime.totalMemory() - runtime.freeMemory()) / (1024 * 1024);
        System.out.println("Used Memory: " + usedMemory + " MB");

        System.out.println("Runtime: " + (endTime - startTime) + " ms");
        System.out.println("Peak Memory Usage: " + usedMemory + " MB");
        
        File file = new File(outputFile);
        System.out.println("Dosyanın tam yolu: " + file.getAbsolutePath());
    }
}
