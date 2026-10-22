// Formulář pro přidání zvířete: při volbě druhu "Jiné" zobrazí pole pro zadání vlastního druhu.
// Skryté pole jQuery validace nekontroluje, takže povinné je jen při volbě "Jiné".
document.addEventListener('DOMContentLoaded', function () {
    const OTHER_SPECIES_VALUE = '-1';

    const speciesSelect = document.getElementById('SpeciesId');
    const otherGroup = document.getElementById('other-species-group');
    const otherInput = document.getElementById('OtherSpeciesName');

    if (!speciesSelect || !otherGroup || !otherInput) {
        return;
    }

    function toggleOtherSpecies(focus) {
        const isOther = speciesSelect.value === OTHER_SPECIES_VALUE;

        otherGroup.classList.toggle('d-none', !isOther);

        if (isOther && focus) {
            otherInput.focus();
        }
    }

    speciesSelect.addEventListener('change', function () {
        toggleOtherSpecies(true);
    });

    // Po neúspěšné validaci na serveru zůstane "Jiné" vybrané -> pole musí být vidět hned.
    toggleOtherSpecies(false);
});
