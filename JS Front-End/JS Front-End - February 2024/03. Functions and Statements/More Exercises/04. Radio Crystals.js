function solve(thicknesses) {
    const finalTickness = thicknesses[0];
    for (let i = 1; i < thicknesses.length; i++) {
        console.log(`Processing chunk ${thicknesses[i]} microns`);
        let custCount = 0, lapsCount = 0, grindsCount = 0, etchesCount = 0, x_rayCount = 0;

        while (thicknesses[i] > finalTickness || thicknesses[i] + 1 === finalTickness) {
            if (thicknesses[i] / 4 >= finalTickness) {
                thicknesses[i] /= 4;
                custCount++;
            } else if ((thicknesses[i] - thicknesses[i] * 0.2 >= finalTickness)) {
                thicknesses[i] -= thicknesses[i] * 0.2;
                lapsCount++;
            } else if (thicknesses[i] - 20 >= finalTickness) {
                thicknesses[i] -= 20;
                grindsCount++;
            } else if (thicknesses[i] - 2 >= finalTickness || thicknesses[i] - 1 === finalTickness) {
                thicknesses[i] -= 2;
                etchesCount++;
            } else if (thicknesses[i] + 1 === finalTickness) {
                thicknesses[i]++;
                x_rayCount++;
            }

            if (x_rayCount === 1) {
                break;
            }

            thicknesses[i] = Math.floor(thicknesses[i]);
        }

        PrintDetailsAboutEachCrystal(custCount, lapsCount, grindsCount, etchesCount, x_rayCount, i);
    }

    function PrintDetailsAboutEachCrystal(custCount, lapsCount, grindsCount, etchesCount, x_rayCount, i) {
        if (custCount > 0) {
            console.log(`Cut x${custCount}`);
            console.log('Transporting and washing');
        }

        if (lapsCount > 0) {
            console.log(`Lap x${lapsCount}`);
            console.log('Transporting and washing');
        }

        if (grindsCount > 0) {
            console.log(`Grind x${grindsCount}`);
            console.log('Transporting and washing');
        }

        if (etchesCount > 0) {
            console.log(`Etch x${etchesCount}`);
            console.log('Transporting and washing');
        }

        if (x_rayCount === 1) {
            console.log('X-ray x1');
        }

        console.log(`Finished crystal ${thicknesses[i]} microns`);
    }
}