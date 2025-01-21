import { BASE_URL } from "@/utils/Constants.ts";

export const uploadFile = async (data: FormData) => {
    try {
        const response = await fetch(`${BASE_URL}/HtmlToPdf/generatePdf`, {
            body: data,
            method: 'POST',
        });

        if (response.ok) {
            const blob = await response.blob();
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');

            a.href = url;
            a.download = 'generated-file.pdf';
            document.body.appendChild(a);
            a.click();
            a.remove();
            window.URL.revokeObjectURL(url);
        } else {
            throw new Error('Request failed due to an unknown issue');
        }

    } catch (error) {
        throw error;
    }
};
