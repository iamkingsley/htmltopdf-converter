import {
  HStack,
  Input,
  Text,
  Heading,
  Spinner,
  VStack,
} from "@chakra-ui/react";
import { ChangeEvent, useRef, useState } from "react";
import useUploadFile from "@/features/file-upload/UploadMutation.ts";

export function UploadPage() {
  const inputRef = useRef<HTMLInputElement>(null);
  const [error, setError] = useState<string>("");
  const uploadMutation = useUploadFile(setError);

  const handleFileUpload = async (event: ChangeEvent<HTMLInputElement>) => {
    const files = event.target.files;

    if (files) {
      const file = files[0];

      const formData = new FormData();
      formData.append("file", file);
      await uploadMutation.mutateAsync(formData);

      if (inputRef.current) {
        inputRef.current.value = "";
      }
    }
  };

  return (
    <>
      <VStack
        width={"full"}
        justifyContent={"center"}
        alignItems={"center"}
        mb={"25px"}
      >
        <Heading
          fontSize={{
            base: "lg",
            md: "2xl",
          }}
        >
          HTML to PDF Convertor
        </Heading>
        <Text fontSize={{ base: "xs", md: "xs" }} color="#eee">
          Select an HTML file to convert to PDF
        </Text>
      </VStack>

      <HStack width={"full"} justifyContent={"center"} alignItems={"center"}>
        <Input
          type="file"
          ref={inputRef}
          size="md"
          accept=".html"
          onChange={handleFileUpload}
          disabled={uploadMutation.isPending}
        ></Input>
      </HStack>

      <HStack width={"full"} justifyContent={"center"} alignItems={"center"}>
        {error && <Text color={"red"}>{error}</Text>}
        {uploadMutation.isPending && (
          <Spinner size={{ base: "sm", md: "xl" }} color={"green"}></Spinner>
        )}
      </HStack>
    </>
  );
}
