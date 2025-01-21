import { uploadFile } from './UploadService';
import { useMutation } from '@tanstack/react-query';

export default function useUploadFile(setError: (error: string) => void) {
    return useMutation({
        mutationFn: (data: FormData) => {
            return uploadFile(data);
        },

        onError: (error: Error) => {
            setError(error.message);
        },

        onSuccess: () => {
            setError('');
        },
    });
}
